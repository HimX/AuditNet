namespace Shared.DataTransferObjects;

public record AuditPlanForCreationDto(string Title, string? Description, IEnumerable<AuditForCreationDto> Audits);