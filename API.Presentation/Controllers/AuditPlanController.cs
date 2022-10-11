using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace API.Presentation.Controllers;

[Route("api/audit_plans")]
[ApiController]
public class AuditPlanController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuditPlanController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAuditPlans()
    {
        var auditPlans = _service.AuditPlanService.GetAllAuditPlans(trackChanges: false);

        return Ok(auditPlans);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAuditPlan(Guid id)
    {
        var auditPlan = _service.AuditPlanService.GetAuditPlan(id, trackChanges: false);
        return Ok(auditPlan);
    }
}