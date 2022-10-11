using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Person
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string LastName { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    public List<AuditPerson> AuditPersons { get; set; } = new List<AuditPerson>();
    public List<Audit> Audits = new List<Audit>();
}