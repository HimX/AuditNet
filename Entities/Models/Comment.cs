namespace Entities.Models;

public class Comment
{
    public Guid Id { get; set; }
    public int? State { get; set; }
    public string Content { get; set; }
}