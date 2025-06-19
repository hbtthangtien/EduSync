using Application.DTOs.Commons;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
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
	}
}
