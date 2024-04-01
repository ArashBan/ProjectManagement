using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Account;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.OwnsMany<Permission>(x => x.Permissions, navigatorBuilder =>
            {
                navigatorBuilder.HasKey(x => x.Id);
                navigatorBuilder.ToTable("Permissions");
                navigatorBuilder.Ignore(x => x.Name);
                navigatorBuilder.WithOwner(x => x.Role);
            });

            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "دانشجو",
                    CreationDate = DateTime.Now
                },
                new Role
                {
                    Id = 2,
                    Name = "استاد",
                    CreationDate = DateTime.Now
                });
        }
    }
}
