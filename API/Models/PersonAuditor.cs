namespace API.Models;

public class PersonAuditor
{
    public Guid AuditId { get; set; }
    public Audit Audit { get; set; }

    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}