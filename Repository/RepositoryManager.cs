using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAuditPlanRepository> _auditPlanRepository;
    private readonly Lazy<IAuditRepository> _auditRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _auditPlanRepository = new Lazy<IAuditPlanRepository>(() =>
            new AuditPlanRepository(repositoryContext));
        _auditRepository = new Lazy<IAuditRepository>(() =>
            new AuditRepository(repositoryContext));
    }

    public IAuditPlanRepository AuditPlan => _auditPlanRepository.Value;
    public IAuditRepository Audit => _auditRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
    public void SaveAsync() => _repositoryContext.SaveChangesAsync();
}