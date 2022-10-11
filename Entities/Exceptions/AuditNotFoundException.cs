namespace Entities.Exceptions;

public class AuditNotFoundException : NotFoundException
{
    public AuditNotFoundException(Guid auditId)
        : base($"Audit with the id: {auditId} does not exist in the database.")
    {
    }
}