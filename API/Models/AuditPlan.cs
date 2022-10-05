using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class AuditPlan
{
    public Guid Id { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; }

    public string Description { get; set; }

    public List<Audit>? Audits { get; set; }

    public CommentPage? CommentPage { get; set; }
}