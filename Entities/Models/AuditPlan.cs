using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class AuditPlan
{
    public Guid Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    public string? Description { get; set; }
    public List<Audit>? Audits { get; set; } = new List<Audit>();

    public CommentPage? CommentPage { get; set; }
}