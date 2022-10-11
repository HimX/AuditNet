using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuditPlanService
{
    IEnumerable<AuditPlanDto> GetAllAuditPlans(bool trackChanges);
    AuditPlanDto GetAuditPlan(Guid auditPlanId, bool trackChanges);
}