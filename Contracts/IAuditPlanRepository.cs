using Entities.Models;

namespace Contracts;

public interface IAuditPlanRepository
{
    IEnumerable<AuditPlan> GetAllAuditPlans(bool trackChanges);
    AuditPlan? GetAuditPlan(Guid auditPlanId, bool trackChanges);
    void CreateAuditPlan(AuditPlan auditPlan);
    IEnumerable<AuditPlan> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
}