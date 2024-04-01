using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Context.Mappings
{
    public class InternshipReportMapping : IEntityTypeConfiguration<InternshipReport>
    {
        public void Configure(EntityTypeBuilder<InternshipReport> builder)
        {
            builder.ToTable("InternshipReports");
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Internship)
                .WithMany(x => x.InternshipReports)
                .HasForeignKey(x => x.InternshipId);
        }
    }
}
