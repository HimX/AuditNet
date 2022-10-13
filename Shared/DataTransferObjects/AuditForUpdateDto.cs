namespace Shared.DataTransferObjects;

public record class AuditForUpdateDto(string Title, string? Description, DateTime StartDate, int State);