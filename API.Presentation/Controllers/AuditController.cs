using Microsoft.AspNetCore.JsonPatch;
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

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAuditForPlan(Guid auditPlanId, Guid id)
    {
        _service.AuditService.DeleteAuditForPlan(auditPlanId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateAuditForPlan(Guid auditPlanId, Guid id, [FromBody] AuditForUpdateDto audit)
    {
        if (audit is null)
            return BadRequest("AuditForUpdateDto object is null");

        _service.AuditService.UpdateAuditForPlan(auditPlanId, id, audit, planTrackChanges: false,
            auditTrackChanges: true);

        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateAuditForPlan(Guid auditPlanId, Guid id,
        [FromBody] JsonPatchDocument<AuditForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result =
            _service.AuditService.GetAuditForPatch(auditPlanId, id, planTrackChanges: false, auditTrackChanges: true);
        patchDoc.ApplyTo(result.auditToPatch);
        _service.AuditService.SaveChangesForPatch(result.auditToPatch, result.auditEntity);

        return NoContent();
    }
}