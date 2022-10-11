namespace Shared.DataTransferObjects;

public record AuditDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public DateTime StartDate { get; init; }
    public int State { get; init; }
    public string? Description { get; init; }
}