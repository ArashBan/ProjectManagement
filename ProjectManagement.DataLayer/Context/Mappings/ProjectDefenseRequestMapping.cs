using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class ProjectDefenseRequestMapping : IEntityTypeConfiguration<ProjectDefenseRequest>
    {
        public void Configure(EntityTypeBuilder<ProjectDefenseRequest> builder)
        {
            builder.ToTable("ProjectDefenseRequests");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.DefenseRequests)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.DefenseRequests)
                .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.DefenseRequests)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
