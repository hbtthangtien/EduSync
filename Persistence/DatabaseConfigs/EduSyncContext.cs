using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseExtensions;
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
		public DbSet<UserToken> UserTokens { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Tutor> Tutors { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<Certificate> Certificates { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Content> Contents { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }

		public DbSet<Slot> Slots { get; set; }
		public DbSet<WeeklySchedule> WeeklySchedules { get; set; }
		public DbSet<CourseCancellation> CourseCancellations { get; set; }
		public DbSet<ActivationRequest> ActivationRequests { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Existing configurations
			modelBuilder.Entity<User>(entity =>
			{
				entity.HasOne(u => u.Role)
					.WithMany(e => e.Users)
					.HasForeignKey(u => u.RoleId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(u => u.Student)
					  .WithOne(u => u.User)
					  .HasForeignKey<Student>(e => e.UserId);

				entity.HasOne(e => e.Tutor)
					.WithOne(e => e.User)
					.HasForeignKey<Tutor>(e => e.UserId);

				entity.HasMany(e => e.UserTokens)
					.WithOne(e => e.User)
					.HasForeignKey(e => e.UserId);

				entity.HasMany(e => e.Payments)
					.WithOne(e => e.User)
					.HasForeignKey(e => e.UserId);

				entity.HasIndex(e => e.Email).IsUnique(true);
				entity.HasIndex(e => e.Username).IsUnique(true);
			});

			modelBuilder.Entity<Student>(entity =>
			{
				entity.HasKey(s => s.UserId);

				entity.HasOne(s => s.User)
					.WithOne(u => u.Student)
					.HasForeignKey<Student>(s => s.UserId) 
					.OnDelete(DeleteBehavior.Cascade);

				entity.HasMany(e => e.CourseCancellations)
					.WithOne(e => e.Student)
					.HasForeignKey(e => e.StudentId);

				entity.HasMany(e => e.Ratings)
					.WithOne(e => e.Student)
					.HasForeignKey(e => e.StudentId);

				entity.HasMany(e => e.Slots)
					.WithOne(e => e.Student)
					.HasForeignKey(e => e.StudentId);
			});


			modelBuilder.Entity<Tutor>(entity =>
			{
				entity.HasMany(e => e.Ratings)
					.WithOne(e => e.Tutor)
					.HasForeignKey(e => e.TutorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasMany(e => e.Courses)
					.WithOne(e => e.CreatedByTutor)
					.HasForeignKey(e => e.CreatedByTutorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasMany(e => e.Certificates)
					.WithOne(e => e.Tutor)
					.HasForeignKey(e => e.TutorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasMany(e => e.Slots)
					.WithOne(e => e.Tutor)
					.HasForeignKey(e => e.TutorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(e => e.BioTutor)
					.WithOne(e => e.Tutor)
					.HasForeignKey<BioTutor>(e => e.TutorId);
			});

			modelBuilder.Entity<ActivationRequest>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Course)
					.WithMany()
					.HasForeignKey(e => e.CourseId)
					.OnDelete(DeleteBehavior.Restrict);
			});
			modelBuilder.Entity<Content>(entity =>
			{
				entity.HasOne(e => e.Course)
					.WithMany(e => e.Contents)
					.HasForeignKey(e => e.CourseId);
			});

			modelBuilder.Entity<Course>(entity =>
			{
				entity.HasMany(e => e.Slots)
					.WithOne(e => e.Course)
					.HasForeignKey(e => e.CourseId);

				entity.HasMany(e => e.WeeklySchedules)
					.WithOne(e => e.Course)
					.HasForeignKey(e => e.CourseId);
			});

			modelBuilder.Entity<CourseCancellation>(entity =>
			{
				entity.HasOne(e => e.Student)
					.WithMany(e => e.CourseCancellations)
					.HasForeignKey(e => e.StudentId);

				entity.HasOne<Payment>()
					.WithOne(e => e.CourseCancellation)
					.HasForeignKey<Payment>(e => e.CourseCancellationId);

				entity.HasOne(e => e.Course)
					.WithMany(e => e.CourseCancellations)
					.HasForeignKey(e => e.CourseId);
			});

			modelBuilder.Entity<Payment>(entity =>
			{
				entity.HasOne(e => e.Course)
					.WithMany()
					.HasForeignKey(e => e.CourseId);
			});

			modelBuilder.Entity<Slot>(entity =>
			{
				entity.HasMany(e => e.WeeklySchedules)
					.WithOne(e => e.Slot)
					.HasForeignKey(e => e.SlotId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(e => e.Student)
					.WithMany(s => s.Slots)
					.HasForeignKey(e => e.StudentId)
					.OnDelete(DeleteBehavior.SetNull); 

				entity.HasOne(e => e.Tutor)
					.WithMany(t => t.Slots)
					.HasForeignKey(e => e.TutorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(e => e.Course)
					.WithMany(c => c.Slots)
					.HasForeignKey(e => e.CourseId)
					.OnDelete(DeleteBehavior.Restrict); 
			});
			modelBuilder.Entity<ChatMessage>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Sender)
					.WithMany() 
					.HasForeignKey(e => e.SenderId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(e => e.Receiver)
					.WithMany() 
					.HasForeignKey(e => e.ReceiverId)
					.OnDelete(DeleteBehavior.Restrict);

				entity.Property(e => e.ConversationId)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Content)
					.IsRequired()
					.HasMaxLength(2000);

				entity.Property(e => e.SentAt)
					.IsRequired();

				entity.HasIndex(e => e.ConversationId);
				entity.Property(e => e.IsRead)
				.IsRequired()
				.HasDefaultValue(false);

				entity.Property(e => e.ReadAt)
					.IsRequired(false);
			});


			modelBuilder.Seed();
		}
	}
}