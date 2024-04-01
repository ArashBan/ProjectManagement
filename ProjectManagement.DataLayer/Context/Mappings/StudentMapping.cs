using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Field).HasMaxLength(150).IsRequired();
            builder.Property(x => x.StudentCode).HasMaxLength(15).IsRequired();

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            builder.HasMany(x => x.DefenseRequests)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            //builder.HasOne(x => x.User)
            //    .WithMany(x => x.Students)
            //    .HasForeignKey(x => x.UserId).IsRequired();
        }
    }
}