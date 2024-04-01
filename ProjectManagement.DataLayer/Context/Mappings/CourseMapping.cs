using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Unit).HasMaxLength(2).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "پروژه",
                    Unit = 2,
                    CreationDate = DateTime.Now
                },
                new Course
                {
                    Id = 2,
                    Name = "کارآموزی",
                    Unit = 2,
                    CreationDate = DateTime.Now
                });
        }
    }
}
