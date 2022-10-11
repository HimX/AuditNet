using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace API.Presentation.Controllers;

[Route("api/audit_plans/{auditPlanId:guid}/audits")]
[ApiController]
public class AuditController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuditController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAuditsForPlan(Guid auditPlanId)
    {
        var audits = _service.AuditService.GetAudits(auditPlanId, trackChanges: false);

        return Ok(audits);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAuditForPlan(Guid auditPlanId, Guid id)
    {
        var audit = _service.AuditService.GetAudit(auditPlanId, id, trackChanges: false);

        return Ok(audit);
    }
}