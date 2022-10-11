using Contracts;
using Entities.Models;

namespace Repository;

public class AuditRepository : RepositoryBase<Audit>, IAuditRepository
{
    public AuditRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}