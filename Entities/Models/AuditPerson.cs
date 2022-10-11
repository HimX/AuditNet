namespace Entities.Models;

public class AuditPerson
{
    public Role Role { get; set; }
    public Audit Audit { get; set; }

    public Guid AuditId { get; set; }

    public Person Person { get; set; }
    public Guid PersonId { get; set; }
}

public enum Role
{
    Manager,
    Auditor,
    Audited
}