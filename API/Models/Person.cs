using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Person
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string LastName { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }

    public List<Audit> Audits = new List<Audit>();
    public List<PersonAudited> PersonAudited = new List<PersonAudited>();
    public List<PersonAuditor> PersonAuditors = new List<PersonAuditor>();
}