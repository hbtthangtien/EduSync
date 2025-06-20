using Application.DTOs.ActivationRequest;
using Application.DTOs.Commons;
using Application.Interfaces.IService;
using Application.IUnitOfWorks;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ActivationRequestService : BaseService, IActivationRequestService
	{
		public ActivationRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<IdResponse> CreateActivationRequest(CreateActivationRequest request, bool saveChange)
		{
			var activation = request.Adapt<ActivationRequest>();
			await _unitOfWork.ActivationRequests.AddAsync(activation);
			if (saveChange)
			{
				await _unitOfWork.SaveChangesAsync();
			}
			return IdResponse.SuccessResponse(activation.Id, "Create success");
		}
	}
}
