using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Position).HasMaxLength(100).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);

            builder.HasMany(x => x.News)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);

            builder.HasMany(x => x.DefenseRequests)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);

            //builder.HasOne(x => x.User)
            //    .WithMany(x => x.Teachers)
            //    .HasForeignKey(x => x.UserId);
        }
    }
}
