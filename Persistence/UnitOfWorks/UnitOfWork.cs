using Application.Interfaces.IRepository;
using Application.IUnitOfWorks;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EduSyncContext _context;
		public IUserRepository User { get; private set; }
		public IRoleRepository Role { get; private set; }
		public IStudentRepository Student { get; private set; }
		public ITuTorRepository TuTor { get; private set; }
		public IUserTokenRepository UserToken { get; private set; }

		public IUserRepository Users { get; private set; }

		public IRoleRepository Roles { get; private set; }

		public IStudentRepository Students { get; private set; }

		public ITuTorRepository TuTors { get; private set; }

		public IUserTokenRepository UserTokens { get; private set; }

		public IActivationRequestRepository ActivationRequests { get; private set; }

		public ICertificateRepository Certificates { get; private set; }

		public IContentRepository Contents { get; private set; }

		public ICourseCancellationRepository CourseCancellations { get; private set; }

		public IPaymentRepository Payments { get; private set; }

		public IRatingRepository Ratings { get; private set; }

		public ISlotRepository Slots { get; private set; }

		public IWeeklyScheduleRepository WeeklySchedules { get; private set; }

		public ICourseRepository Courses { get; private set; }

		public IChatMessageRepository ChatMessages { get; private set; }

		public UnitOfWork(EduSyncContext context,
			IUserRepository user,
			IRoleRepository role,
			IStudentRepository student,
			ITuTorRepository tuTor,
			IUserTokenRepository userToken,
			IUserRepository users,
			IRoleRepository roles,
			IStudentRepository students,
			ITuTorRepository tuTors,
			IUserTokenRepository userTokens,
			IActivationRequestRepository activationRequests,
			ICertificateRepository certificates,
			IContentRepository contents,
			ICourseCancellationRepository courseCancellations,
			IPaymentRepository payments,
			IRatingRepository ratings,
			ISlotRepository slots,
			IWeeklyScheduleRepository weeklySchedules,
			ICourseRepository courses,
			IChatMessageRepository chatMessage)
		{
			ChatMessages = chatMessage;
			_context = context;
			User = user;
			Role = role;
			Student = student;
			TuTor = tuTor;
			UserToken = userToken;
			Users = users;
			Roles = roles;
			Students = students;
			TuTors = tuTors;
			UserTokens = userTokens;
			ActivationRequests = activationRequests;
			Certificates = certificates;
			Contents = contents;
			CourseCancellations = courseCancellations;
			Payments = payments;
			Ratings = ratings;
			Slots = slots;
			WeeklySchedules = weeklySchedules;
			Courses = courses;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();

		}
	}


}
