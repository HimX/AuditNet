namespace Shared.DataTransferObjects;

public record AuditPlanForUpdateDto(string Title, string? Description, IEnumerable<AuditForCreationDto> Audits);