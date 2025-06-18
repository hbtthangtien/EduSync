using Application.DTOs.Register;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationMappers
{
	public static class MapsterConfig
	{
		public static void RegisterMappings()
		{
			// RegisterDTO → User
			TypeAdapterConfig<RegisterDTO, User>
				.NewConfig()
				.Map(dest => dest.Username, src => src.Username)
				.Map(dest => dest.Email, src => src.Email)
				.Ignore(dest => dest.PasswordHash) // set riêng sau khi hash
				.Map(dest => dest.RoleId, src => src.RoleId)
				.Ignore(dest => dest.Id) // do DB set tự sinh
				.Ignore(dest => dest.CreatedAt)
				.Ignore(dest => dest.UpdatedAt)
				.Ignore(dest => dest.DeletedAt);
		}
	}
}
