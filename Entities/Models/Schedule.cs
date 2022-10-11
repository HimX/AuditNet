using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Schedule
{
    public Guid Id { get; set; }
    [Required] [MaxLength(255)] public string Title { get; set; }
    public string? Description { get; set; }
    [Required] public DateTime StartDate { get; set; }
    public CommentPage? CommentPage { get; set; }
}