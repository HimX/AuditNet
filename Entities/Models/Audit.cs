using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Audit
{
    public Guid Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public int State { get; set; }
    public Guid AuditPlanId { get; set; }
    public List<Schedule>? Schedules { get; set; } = new List<Schedule>();
    public List<Person>? Persons { get; set; } = new List<Person>();
    public List<AuditPerson> AuditPersons { get; set; } = new List<AuditPerson>(); 
    public CommentPage? CommentPage { get; set; }
}