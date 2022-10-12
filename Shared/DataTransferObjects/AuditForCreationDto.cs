namespace Shared.DataTransferObjects;

public record AuditForCreationDto(string Title, string? Description, DateTime StartDate, int State);