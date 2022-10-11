namespace Contracts;

public interface IRepositoryManager
{
    IAuditPlanRepository AuditPlan { get; }
    IAuditRepository Audit { get; }
    void Save();
    void SaveAsync();
}