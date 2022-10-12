using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

    [HttpGet("{id:guid}", Name = "GetAuditForPlan")]
    public IActionResult GetAuditForPlan(Guid auditPlanId, Guid id)
    {
        var audit = _service.AuditService.GetAudit(auditPlanId, id, trackChanges: false);

        return Ok(audit);
    }

    [HttpPost]
    public IActionResult CreateAuditForPlan(Guid auditPlanId, [FromBody] AuditForCreationDto audit)
    {
        if (audit is null)
            return BadRequest("AuditForCreationDto object is null");

        var auditToReturn = _service.AuditService.CreateAuditForPlan(auditPlanId, audit, trackChanges: false);

        return CreatedAtRoute("GetAuditForPlan", new {auditPlanId, id = auditToReturn.Id}, auditToReturn);
    }
}