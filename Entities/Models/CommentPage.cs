namespace Entities.Models;

public class CommentPage
{
    public Guid Id { get; set; }
    public List<Comment>? Comments { get; set; } = new List<Comment>();
}