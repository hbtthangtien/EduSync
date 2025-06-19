using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface ISlotService
	{
		Task<BaseResponse<string>> RegisterSlotAsync(long slotId, long userId);

	}
}
