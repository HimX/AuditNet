using API.Models;

namespace API.Repository;

public interface IAuditRepository
{
    Task<List<Audit>> GetAuditsAsync();

    Task<Audit?> GetAuditAsync(Guid? auditId);

    Task<int> AddAuditAsync(Audit audit);

    Task<int> DeleteAuditAsync(Guid? auditId);

    Task<int> UpdateAuditAsync(Audit newAudit);
}