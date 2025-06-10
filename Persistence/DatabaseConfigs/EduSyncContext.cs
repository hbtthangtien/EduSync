using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseConfigs
{
	public class EduSyncContext : DbContext
	{
		public EduSyncContext(DbContextOptions<EduSyncContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Tutor> Tutors { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<Certificate> Certificates { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Content> Contents { get; set; }
		public DbSet<Slot> Slots { get; set; }
		public DbSet<WeeklySchedule> WeeklySchedules { get; set; }

		public DbSet<CourseCancellation> CourseCancellations { get; set; } 
		public DbSet<ActivationRequest> ActivationRequests { get; set; } 
		public DbSet<TutorPayment> TutorPayments { get; set; } 


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasOne(u => u.Role)
				.WithMany()
				.HasForeignKey(u => u.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Student>()
				.HasOne(s => s.User)
				.WithOne()
				.HasForeignKey<Student>(s => s.Id)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Rating>()
				.HasOne(r => r.Tutor)
				.WithOne(t => t.Rating) 
				.HasForeignKey<Rating>(r => r.TutorId)
				.OnDelete(DeleteBehavior.Restrict); 
			
			modelBuilder.Entity<Tutor>()
				.HasOne(t => t.User)
				.WithOne()
				.HasForeignKey<Tutor>(t => t.Id)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Tutor>()
				.HasOne(t => t.Certificate)
				.WithMany()
				.HasForeignKey(t => t.CertificateId)
				.OnDelete(DeleteBehavior.Restrict);

			//modelBuilder.Entity<Tutor>()
			//	.HasOne(t => t.Rating)
			//	.WithOne()
			//	.HasForeignKey<Tutor>(t => t.RatingId)
			//	.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Certificate>()
				.HasOne(c => c.Tutor)
				.WithMany()
				.HasForeignKey(c => c.TutorId)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Certificate>()
				.HasOne(c => c.VerifiedByAdmin)
				.WithMany()
				.HasForeignKey(c => c.VerifiedByAdminId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Payment>()
				.HasOne(p => p.User)
				.WithMany()
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Course>()
				.HasOne(c => c.CreatedByTutor)
				.WithMany()
				.HasForeignKey(c => c.CreatedByTutorId)
				.OnDelete(DeleteBehavior.Restrict); 


			modelBuilder.Entity<Content>()
				.HasOne(c => c.Course)
				.WithMany(c => c.Contents)
				.HasForeignKey(c => c.CourseId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.Slots)
				.WithOne()
				.HasForeignKey(s => s.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.WeeklySchedules)
				.WithOne()
				.HasForeignKey(ws => ws.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			//modelBuilder.Entity<Slot>()
			//	.HasOne(s => s.Course)
			//	.WithMany(c => c.Slots)
			//	.HasForeignKey(s => s.CourseId)
			//	.OnDelete(DeleteBehavior.Cascade);

			//modelBuilder.Entity<Slot>()
			//	.HasOne(s => s.Tutor)
			//	.WithMany()
			//	.HasForeignKey(s => s.TutorId)
			//	.OnDelete(DeleteBehavior.Cascade);

			//modelBuilder.Entity<Slot>()
			//	.HasOne(s => s.Student)
			//	.WithMany()
			//	.HasForeignKey(s => s.StudentId)
			//	.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<WeeklySchedule>()
				.HasOne(ws => ws.Course)
				.WithMany(c => c.WeeklySchedules)
				.HasForeignKey(ws => ws.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CourseCancellation>()
				.HasOne(cc => cc.Student)
				.WithMany()
				.HasForeignKey(cc => cc.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CourseCancellation>()
				.HasOne(cc => cc.Payment)
				.WithMany()
				.HasForeignKey(cc => cc.PaymentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ActivationRequest>()
				.HasOne(ar => ar.Course)
				.WithMany()
				.HasForeignKey(ar => ar.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ActivationRequest>()
				.HasOne(ar => ar.Admin)
				.WithMany()
				.HasForeignKey(ar => ar.AdminId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<TutorPayment>()
				.HasOne(tp => tp.Tutor)
				.WithMany()
				.HasForeignKey(tp => tp.TutorId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<TutorPayment>()
				.HasOne(tp => tp.Payment)
				.WithMany()
				.HasForeignKey(tp => tp.PaymentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Course>()
				.Property(c => c.TrialSessions)
				.HasDefaultValue(2);

			modelBuilder.Entity<Course>()
				.Property(c => c.ServiceFeePercentage)
				.HasDefaultValue(5);

			modelBuilder.Entity<Slot>()
				.HasOne(s => s.Course)
				.WithMany(c => c.Slots)
				.HasForeignKey(s => s.CourseId)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Slot>()
				.HasOne(s => s.Tutor)
				.WithMany(t => t.Slots)
				.HasForeignKey(s => s.TutorId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Slot>()
				.HasOne(s => s.Student)
				.WithMany(st => st.Slots)
				.HasForeignKey(s => s.StudentId)
				.OnDelete(DeleteBehavior.SetNull);

		}
	}
}

