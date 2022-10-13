using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuditPlanService
{
    IEnumerable<AuditPlanDto> GetAllAuditPlans(bool trackChanges);
    AuditPlanDto GetAuditPlan(Guid auditPlanId, bool trackChanges);
    AuditPlanDto CreateAuditPlan(AuditPlanForCreationDto auditPlan);
    IEnumerable<AuditPlanDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

    (IEnumerable<AuditPlanDto> plans, string ids) CreateAuditPlanCollection
        (IEnumerable<AuditPlanForCreationDto> auditPlanCollection);

    void DeleteAuditPlan(Guid auditPlanId, bool trackChanges);
    void UpdateAuditPlan(Guid auditPlanId, AuditPlanForUpdateDto auditPlanForUpdate, bool trackChanges);
}