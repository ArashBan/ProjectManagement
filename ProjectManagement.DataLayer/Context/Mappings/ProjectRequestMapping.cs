using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class ProjectRequestMapping : IEntityTypeConfiguration<ProjectRequest>
    {
        public void Configure(EntityTypeBuilder<ProjectRequest> builder)
        {
            builder.ToTable("ProjectRequests");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Puprpose).HasMaxLength(500).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.ProjectRequests)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.ProjectRequests)
                .HasForeignKey(x => x.TeacherId);

            builder.HasMany(x => x.DefenseRequests)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

        }
    }
}
