namespace Service.Contracts;

public interface IServiceManager
{
    IAuditPlanService AuditPlanService { get; }
    IAuditService AuditService { get; }
}