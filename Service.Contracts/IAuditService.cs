using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuditService
{
    IEnumerable<AuditDto> GetAudits(Guid auditPlanId, bool trackChanges);
    AuditDto GetAudit(Guid auditPlanId, Guid id, bool trackChanges);
    AuditDto CreateAuditForPlan(Guid auditPlanId, AuditForCreationDto auditForCreationDto, bool trackChanges);
    void DeleteAuditForPlan(Guid auditPlanId, Guid id, bool trackChanges);

    void UpdateAuditForPlan(Guid auditPlanId, Guid id, AuditForUpdateDto auditForUpdateDto, bool planTrackChanges,
        bool auditTrackChanges);

    (AuditForUpdateDto auditToPatch, Audit auditEntity) GetAuditForPatch(Guid auditPlanId, Guid id,
        bool planTrackChanges, bool auditTrackChanges);

    void SaveChangesForPatch(AuditForUpdateDto auditToPatch, Audit auditEntity);
}