using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuditPlanController : BaseApiController
{
    private readonly AuditService _service;

    public AuditPlanController(AuditService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuditPlan>>> GetPlans()
    {
        var plans = await _service.GetPlansAsync();
        return Ok(plans);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AuditPlan>> GetPlanById(Guid id)
    {
        var plan = await _service.GetPlanByIdAsync(id);
        return Ok(plan);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePlan(AuditPlan newPlan)
    {
        newPlan.Id = Guid.NewGuid();
        var plan = await _service.CreatePlanAsync(newPlan);
        return CreatedAtAction(nameof(CreatePlan), new {id = plan!.Id}, plan);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePlanById(Guid id)
    {
        var plan = await _service.GetPlanByIdAsync(id);

        if (plan is null) return NotFound();

        await _service.DeletePlanByIdAsync(id);
        return Ok();
    }

    [HttpGet("{id:guid}/Audit")]
    public async Task<ActionResult<AuditPlan>> GetAuditsByPlanId(Guid id)
    {
        try
        {
            var plan = await _service.GetAuditsByPlanIdAsync(id);
            return Ok(plan);
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
    }

    [HttpPost("{id:guid}/Audit")]
    public async Task<ActionResult<Audit?>> AddAuditToPlan(Guid id, Audit newAudit)
    {
        newAudit.Id = Guid.NewGuid();
        var audit = await _service.AddAuditToPlanAsync(id, newAudit);

        if (audit is null) return NotFound();

        return Ok(audit);
    }
}