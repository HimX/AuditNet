using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuditPlanService> _auditPlanService;
    private readonly Lazy<IAuditService> _auditService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _auditPlanService = new Lazy<IAuditPlanService>(() => new AuditPlanService(repositoryManager, mapper));
        _auditService = new Lazy<IAuditService>(() => new AuditService(repositoryManager, mapper));
    }

    public IAuditPlanService AuditPlanService => _auditPlanService.Value;
    public IAuditService AuditService => _auditService.Value;
}