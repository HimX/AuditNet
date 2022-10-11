using Contracts;
using Entities.Models;

namespace Repository;

public class AuditPlanRepository : RepositoryBase<AuditPlan>, IAuditPlanRepository
{
    public AuditPlanRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<AuditPlan> GetAllAuditPlans(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Title)
            .ToList();
}