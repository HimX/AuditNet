namespace Shared.DataTransferObjects;

public record AuditPlanDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}