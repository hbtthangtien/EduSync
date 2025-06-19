using Application.DTOs.Commons;
using Application.DTOs.Tutors.Bio;
using Application.DTOs.Tutors.Slots;
using Application.Extentions;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class TutorService : BaseService, ITutorService
	{
		public TutorService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<IdResponse> UpdateBioTutors(BioUpdate request)
		{
			var tutor = await _unitOfWork.TuTors
				.GetInstance()
				.Where(e => e.UserId == request.UserId)
				.Include(e => e.BioTutor)
				.FirstOrDefaultAsync() ??
				throw ExceptionFactory.NotFound("Tutor", request.UserId);
			if(request.Introduces != null)
			{
				tutor!.BioTutor!.Introduces = request.Introduces;
			}
			if(request.Specializations != null)
			{
				tutor!.BioTutor!.Specializations = request.Specializations;
			}
			if(request.FullName != null)
			{
				tutor!.BioTutor!.Fullname = request.FullName;
			}
			
			await _unitOfWork.SaveChangesAsync();
			return IdResponse.SuccessResponse(tutor.UserId, "Update success");
		}
		public async Task<BaseResponse<List<SlotTutorDTO>>> GetSlotsBytutorAsync(long tutorId)
		{
			var tutor = await _unitOfWork.TuTors.GetInstance()
				.Where(e => e.UserId == tutorId)
				.Include(e => e.Slots)
				.ThenInclude(s => s.Course)
				.AsNoTracking()
				.FirstOrDefaultAsync();

			var result = tutor.Slots
				.GroupBy(s => new { s.StartTime.Date, s.Course.Title })
				.Select(g => new SlotTutorDTO
				{
					Id = tutor.UserId,
					Date = g.Key.Date,
					CourseTitle = g.Key.Title,
					Shifts = g.Select(s => $"{s.StartTime:HH\\:mm} - {s.EndTime:HH\\:mm}").ToList()
				})
				.ToList();
			return BaseResponse<List<SlotTutorDTO>>.SuccessResponse(result);
		}
	}
}
