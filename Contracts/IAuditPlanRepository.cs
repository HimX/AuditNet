using Entities.Models;

namespace Contracts;

public interface IAuditPlanRepository
{
    IEnumerable<AuditPlan> GetAllAuditPlans(bool trackChanges);
}