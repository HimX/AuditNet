using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace API.Presentation.Controllers;

[Route("api/audit_plan")]
[ApiController]
public class AuditPlanController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuditPlanController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetAuditPlans()
    {
        try
        {
            var auditPlans = _service.AuditPlanService.GetAllAuditPlans(trackChanges: false);

            return Ok(auditPlans);
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}