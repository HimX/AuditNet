using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

public class Schedule
{
    public Guid Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    public string Description { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [JsonIgnore] public CommentPage? CommentPage { get; set; }
}