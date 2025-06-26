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
            var durationOfCourse = await _unitOfWork.Courses
				.GetInstance()
				.Where(e => e.Id == slots.CourseId && e.CreatedByTutorId == tutorId && e.Status == Domain.Enums.CourseStatus.Published)
				.Select(e => new { e.DurationSession , e.NumberOfSession})
				.FirstOrDefaultAsync() 
				?? throw ExceptionFactory.Business("The course is not found or not published");
			var listWeeklySchedule = GenerateWeeklySchedule(slots, durationOfCourse.DurationSession, (short)durationOfCourse.NumberOfSession);
			var dateStart = listWeeklySchedule.First().StartTime;
			var studentId = await _unitOfWork.Users.GetInstance()
					.Where(e => e.Email == slots.StudentEmail && e.RoleId == 3)
					.Select(e => new { e.Id })
					.FirstOrDefaultAsync()
					?? throw ExceptionFactory.NotFound("Student", slots.StudentEmail);								
			var slot = new Slot
			{
				CourseId = slots.CourseId,
				DurationSession = durationOfCourse.DurationSession,
				IsBooked = true,
				MeetUrl = slots.MeetUrl,
				IsTrial = true,
				StartTime = dateStart,
				TutorId = tutorId,
				NumberOfSlot = (short)durationOfCourse.NumberOfSession,
				WeeklySchedules = listWeeklySchedule,
				StudentId = studentId.Id				
			};
			if (!await IsOverlappingSchedule(slot,slots.DayOfWeeks))
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
            var results = new Dictionary<DayOfWeek, int>();
            if (days == null || days.Count < 2)
                return results; 
            for (int i = 0; i < days.Count - 1; i++)
            {
                int distance = ((int)days[i + 1] - (int)days[i] + 7) % 7;
                if (distance == 0) distance = 7; 
                results[days[i]] = distance;
            }
            int lastDistance = ((int)days.First() - (int)days.Last() + 7) % 7;
            if (lastDistance == 0) lastDistance = 7;
            results[days.Last()] = lastDistance;
            return results;
        }

		private List<WeeklySchedule> GenerateWeeklySchedule(CreateSlot slots, TimeSpan durationOfCourse,short NumberOfSession)
		{
			var dateStart = DateTime.Now.Date;
			dateStart =  dateStart.AddMinutes(slots.StartTime.TotalMinutes);
            var distanceDayOfWeek = GetDistanceOfDayOfWeek(slots.DayOfWeeks);
			var list = new List<WeeklySchedule>();
			var duration = durationOfCourse.TotalMinutes;
			int dayStep = NumberOfSession / slots.DayOfWeeks.Count;
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

        private async Task<bool> IsOverlappingSchedule(Slot slot, List<DayOfWeek> dayOfWeeks)
        {
            // Lấy tất cả lịch đã tồn tại của Course này và các ngày sẽ check
            var existedSchedules = await _unitOfWork.WeeklySchedules
                .GetInstance()
                .Where(e => e.CourseId == slot.CourseId && dayOfWeeks.Contains(e.DayOfWeek))
                .ToListAsync();

            // Duyệt từng WeeklySchedule sẽ tạo mới (giả sử bạn dùng GenerateWeeklySchedule rồi)
            var newSchedules = slot.WeeklySchedules; // <-- bạn đã gán trước khi gọi hàm này

            foreach (var newSchedule in newSchedules)
            {
                // Kiểm tra có cái nào trùng trong DB không
                bool overlap = existedSchedules.Any(e =>
                    e.DayOfWeek == newSchedule.DayOfWeek
                    && newSchedule.StartTime < e.EndTime
                    && e.StartTime < newSchedule.EndTime
                );
                if (overlap)
                    return true; // Phát hiện trùng, dừng luôn
            }

            return false; // Không có trùng nào hết
        }
    }
}
