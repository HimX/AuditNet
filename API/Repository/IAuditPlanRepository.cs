using API.Models;

namespace API.Repository;

public interface IAuditPlanRepository
{
    Task<List<AuditPlan>> GetPlansAsync();

    Task<AuditPlan?> GetPlanAsync(Guid? planId);

    Task<int> AddPlanAsync(AuditPlan auditPlan);

    Task<int> DeletePlanAsync(Guid? planId);

    Task<int> UpdatePlanAsync(AuditPlan auditPlan);
}