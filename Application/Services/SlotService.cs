using Application.DTOs.Commons;
using Application.DTOs.Tutors.Slots;
using Application.Extentions;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class SlotService : ISlotService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SlotService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IdResponse> CreateSlotWithScheduleAsync(long tutorId, CreateSlot slots)
		{
			var dateStart = slots.StartTime.Day;
			var timeStart = slots.StartTime.TimeOfDay;
			var listWeeklySchedule = GenerateWeeklySchedule(slots);
			var studentId = await _unitOfWork.Users.GetInstance()
					.Where(e => e.Email == slots.StudentEmail && e.RoleId == 3)
					.Select(e => e.Id)
					.FirstOrDefaultAsync();
			var slot = new Slot
			{
				CourseId = slots.CourseId,
				DurationSession = slots.Durations,
				IsBooked = true,
				MeetUrl = slots.MeetUrl,
				IsTrial = true,
				StartTime = slots.StartTime,
				TutorId = tutorId,
				NumberOfSlot = slots.NumberOfSession,
				WeeklySchedules = listWeeklySchedule,
				StudentId = studentId				
			};
			if (await IsOverlappingSchedule(slot,slots.DayOfWeeks))
			{
				await _unitOfWork.Slots.AddAsync(slot);
				await _unitOfWork.SaveChangesAsync();
				return IdResponse.SuccessResponse(slot.Id,"Add successfully");
			}
			throw ExceptionFactory.Conflict("Slots",slot.StartTime.ToString("F"));
		}

		public async Task<BaseResponse<string>> RegisterSlotAsync(long slotId, long userId)
		{
			try
			{
				var user = await _unitOfWork.Users.GetByIdAsync(userId);
				if (user == null || user.RoleId != 3)
					return BaseResponse<string>.ErrorResponse("Chỉ student mới có quyền đăng ký slot");

				var student = await _unitOfWork.Students.FindAsync(s => s.UserId == userId);
				if (student == null)
					return BaseResponse<string>.ErrorResponse("Không tìm thấy thông tin student");

				var slot = await _unitOfWork.Slots.GetByIdAsync(slotId);
				if (slot == null)
					return BaseResponse<string>.ErrorResponse("Slot không tồn tại");

				if (slot.IsBooked || slot.StudentId != null)
					return BaseResponse<string>.ErrorResponse("Slot đã được đăng ký bởi người khác");

				slot.StudentId = student.UserId;
				slot.IsBooked = true;

				await _unitOfWork.SaveChangesAsync();

				return BaseResponse<string>.SuccessResponse("Đăng ký slot thành công!", null, "OK");
			}
			catch (Exception ex)
			{
				return BaseResponse<string>.ErrorResponse("Lỗi hệ thống xảy ra", new Dictionary<string, string>
		{
			{ "exception", ex.Message }
		});
			}
		}

		private Dictionary<DayOfWeek, int> GetDistanceOfDayOfWeek(List<DayOfWeek> days)
		{
			Dictionary<DayOfWeek,int> results = new Dictionary<DayOfWeek, int>();
			for(int i = 0;i<days.Count-1;i++)
			{
				results[days[i]]=(days[i + 1] - days[i]);
			}
			int lastResult = (int)(DayOfWeek.Sunday - days.Last() + days.First());
			results[days.Last()]=Math.Abs(lastResult);
			return results;
		}

		private List<WeeklySchedule> GenerateWeeklySchedule(CreateSlot slots)
		{
			var dateStart = slots.StartTime;
			var distanceDayOfWeek = GetDistanceOfDayOfWeek(slots.DayOfWeeks);
			var list = new List<WeeklySchedule>();
			var duration = slots.Durations.TotalMinutes;
			int dayStep = slots.NumberOfSession / slots.DayOfWeeks.Count;
			bool isAddFirstTime = false;

			// check if start day is tuesday and slot include monday, wednesday, friday
			bool check = dateStart.DayOfWeek - slots.DayOfWeeks.First() <= 0;
			for (int i = 0; i<dayStep; i++)
			{
				
				foreach(var j in distanceDayOfWeek)
				{					
					if (check && !isAddFirstTime)
                    {
						dateStart = dateStart.AddDays(dateStart.DayOfWeek - slots.DayOfWeeks.First());
						var weeklySchedule = new WeeklySchedule
						{
							CourseId = slots.CourseId,
							StartTime = dateStart,
							EndTime = dateStart.AddMinutes(duration),
							DayOfWeek = j.Key,
						};
						list.Add(weeklySchedule);
						isAddFirstTime = true;
					}
					else
					{
						dateStart = dateStart.AddDays(j.Value);
						var weeklySchedule = new WeeklySchedule
						{
							CourseId = slots.CourseId,
							StartTime = dateStart,
							EndTime = dateStart.AddMinutes(duration),
							DayOfWeek = j.Key,
						};
						list.Add(weeklySchedule);
					}
                    
				}
			}
			return list;
		}

		private async Task<bool> IsOverlappingSchedule(Slot slot,List<DayOfWeek> dayOfWeeks)
		{
			var check = await _unitOfWork.WeeklySchedules
				.GetInstance()
				.Where(e => e.CourseId == slot.CourseId 
							&& dayOfWeeks.Contains(e.DayOfWeek)
							&& ((slot.StartTime <= e.EndTime && slot.StartTime >= e.StartTime)
							|| (slot.EndTime >= e.StartTime && slot.EndTime <= e.EndTime)))
				.AnyAsync();
			return !check;
		}
	}
}
