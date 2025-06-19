using Application.DTOs.Register;
using Application.DTOs.RegisterTutor;
using Application.DTOs.User;
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
			TypeAdapterConfig<RegisterDTO, User>
				.NewConfig()
				.Map(dest => dest.Username, src => src.Username)
				.Map(dest => dest.Email, src => src.Email)
				.Ignore(dest => dest.PasswordHash)
				.Ignore(dest => dest.Id)
				.Ignore(dest => dest.CreatedAt)
				.Ignore(dest => dest.UpdatedAt)
				.Ignore(dest => dest.DeletedAt);


			TypeAdapterConfig<RegisterTutorDTO, Tutor>
				.NewConfig()
				.Ignore(dest => dest.Certificates)
				.Ignore(dest => dest.ActivationRequests)
				.Ignore(dest => dest.Students)
				.Ignore(dest => dest.BioTutor);

			TypeAdapterConfig<RegisterTutorDTO, BioTutor>
				.NewConfig()
				.Map(dest => dest.Fullname, src => src.Fullname)
				.Map(dest => dest.Specializations, src => src.Specializations)
			.Map(dest => dest.Introduces, src => src.Introduces);

			TypeAdapterConfig<Course, DashboardCourseSummaryDTO>.NewConfig()
				.Map(dest => dest.Title, src => src.Title)
				.Map(dest => dest.TutorName, src => src.CreatedByTutor!.BioTutor!.Fullname)
				.Map(dest => dest.StudentCount, src => src.Slots!
					.Where(s => s.StudentId.HasValue)
					.Select(s => s.StudentId!.Value)
					.Distinct()
					.Count());

		}
	}
}
