using Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IUnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		public IUserRepository Users {  get; }
		public IRoleRepository Roles { get; }
		public IStudentRepository Students { get; }
		public ITuTorRepository TuTors { get; }
		public IUserTokenRepository UserTokens { get; }
		public IActivationRequestRepository ActivationRequests { get; }
		public ICertificateRepository Certificates { get; }
		public IContentRepository Contents { get; }
		public ICourseCancellationRepository CourseCancellations { get; }
		public IPaymentRepository Payments { get; }
		public IRatingRepository Ratings { get; }
		public ISlotRepository Slots { get; }
		public IWeeklyScheduleRepository WeeklySchedules { get; }
		public IChatMessageRepository ChatMessages { get; }
		public ICourseRepository Courses { get; }
		Task<int> SaveChangesAsync();
	}
}
