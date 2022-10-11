using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class AuditPlanConfiguration : IEntityTypeConfiguration<AuditPlan>
{
    public void Configure(EntityTypeBuilder<AuditPlan> builder)
    {
        builder.HasData(
            new AuditPlan
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Title = "First plan",
                Description = "First plan description"
            },
            new AuditPlan
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Title = "Second plan",
                Description = "Second plan description"
            }
        );
    }
}