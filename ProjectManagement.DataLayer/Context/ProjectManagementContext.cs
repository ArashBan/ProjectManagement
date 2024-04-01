using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataLayer.Context.Mappings;
using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Context
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options)
        {

        }

        #region People

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        #endregion

        #region Courses

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        public DbSet<ProjectProgress> ProjectProgresses { get; set; }
        public DbSet<InternshipRequest> InternshipRequests { get; set; }
        public DbSet<InternshipReport> InternshipReports { get; set; }

        public DbSet<ProjectDefenseRequest> ProjectDefenseRequests { get; set; }

        #endregion

        #region Account

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        #endregion

        #region Common

        public DbSet<Problem> Problems { get; set; }
        public DbSet<News> News { get; set; }

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var assembly = typeof(StudentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
