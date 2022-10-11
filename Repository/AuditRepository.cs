using Contracts;
using Entities.Models;

namespace Repository;

public class AuditRepository : RepositoryBase<Audit>, IAuditRepository
{
    public AuditRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Audit> GetAudits(Guid auditPlanId, bool trackChanges)
    {
        return FindByCondition(audit => audit.AuditPlanId.Equals(auditPlanId), trackChanges)
            .OrderBy(audit => audit.Title).ToList();
    }

    public Audit GetAudit(Guid auditPlanId, Guid id, bool trackChanges)
    {
        return FindByCondition(audit => audit.AuditPlanId.Equals(auditPlanId) && audit.Id.Equals(id),
                trackChanges)
            .SingleOrDefault();
    }
}