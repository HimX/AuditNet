using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuditService
{
    IEnumerable<AuditDto> GetAudits(Guid auditPlanId, bool trackChanges);
    AuditDto GetAudit(Guid auditPlanId, Guid id, bool trackChanges);
}