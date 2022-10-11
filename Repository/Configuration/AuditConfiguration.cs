using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class AuditConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.HasData(
            new Audit
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Title = "First audit",
                Description = "First audit description",
                State = 0,
                StartDate = DateTime.Now,
                AuditPlanId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Audit
            {
                Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Title = "Second audit",
                Description = "Second audit description",
                State = 0,
                StartDate = DateTime.Now,
                AuditPlanId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
            }
        );
    }
}