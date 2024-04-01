using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class InternshipRequestMapping : IEntityTypeConfiguration<InternshipRequest>
    {
        public void Configure(EntityTypeBuilder<InternshipRequest> builder)
        {
            builder.ToTable("InternshipRequests");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.InternshipRequests)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.InternshipRequests)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}