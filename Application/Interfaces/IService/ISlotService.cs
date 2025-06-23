using Application.DTOs.ActivationRequest;
using Application.DTOs.Commons;
using Application.DTOs.Tutors.Slots;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ISlotService
	{
		Task<BaseResponse<string>> RegisterSlotAsync(long slotId, long userId);

		Task<IdResponse> CreateSlotWithScheduleAsync(long tutorId, CreateSlot slots);
	}
}
