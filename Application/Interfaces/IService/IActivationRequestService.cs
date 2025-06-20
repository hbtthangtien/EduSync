using Application.DTOs.ActivationRequest;
using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface IActivationRequestService
	{
		Task<IdResponse> CreateActivationRequest(CreateActivationRequest request, bool saveChange = true);
	}
}
