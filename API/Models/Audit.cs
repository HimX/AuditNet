using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class Audit
{
    public Guid Id { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public int State { get; set; }

    public List<Schedule>? Schedules { get; set; } = new List<Schedule>();
    [JsonIgnore] public CommentPage? CommentPage { get; set; }
}