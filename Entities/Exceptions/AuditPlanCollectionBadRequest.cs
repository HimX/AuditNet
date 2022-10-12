namespace Entities.Exceptions;

public class AuditPlanCollectionBadRequest : BadRequestException
{
    public AuditPlanCollectionBadRequest() : base("Audit plan collection sent from client is null.")
    {
    }
}