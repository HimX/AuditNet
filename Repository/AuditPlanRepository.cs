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

    public AuditPlan? GetAuditPlan(Guid auditPlanId, bool trackChanges) =>
        FindByCondition(ap => ap.Id.Equals(auditPlanId), trackChanges)
            .SingleOrDefault();

    public void CreateAuditPlan(AuditPlan auditPlan) => Create(auditPlan);

    public IEnumerable<AuditPlan> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(ap => ids.Contains(ap.Id), trackChanges)
            .ToList();

    public void DeleteAuditPlan(AuditPlan auditPlan) => Delete(auditPlan);
}