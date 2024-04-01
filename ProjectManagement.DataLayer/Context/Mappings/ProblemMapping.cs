using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class ProblemMapping : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.ToTable("Problems");
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
