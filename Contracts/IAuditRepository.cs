using Entities.Models;

namespace Contracts;

public interface IAuditRepository
{
    IEnumerable<Audit> GetAudits(Guid auditPlanId, bool trackChanges);
    Audit GetAudit(Guid auditPlanId, Guid id, bool trackChanges);
    void CreateAuditForPlan(Guid auditPlanId, Audit audit);
}