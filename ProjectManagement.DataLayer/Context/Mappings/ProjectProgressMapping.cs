using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class ProjectProgressMapping : IEntityTypeConfiguration<ProjectProgress>
    {
        public void Configure(EntityTypeBuilder<ProjectProgress> builder)
        {
            builder.ToTable("ProjectProgresses");
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.ProjectProgresses)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
