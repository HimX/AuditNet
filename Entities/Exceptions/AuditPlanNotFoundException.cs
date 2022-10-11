namespace Entities.Exceptions;

public class AuditPlanNotFoundException : NotFoundException
{
    public AuditPlanNotFoundException(Guid auditPlanId) : base(
        $"The audit plan with id: {auditPlanId} does not exist in the database.")
    {
    }
}