using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

    [HttpGet("{id:guid}", Name = "AuditPlanById")]
    public IActionResult GetAuditPlan(Guid id)
    {
        var auditPlan = _service.AuditPlanService.GetAuditPlan(id, trackChanges: false);
        return Ok(auditPlan);
    }

    [HttpPost]
    public IActionResult CreateAuditPlan([FromBody] AuditPlanForCreationDto auditPlan)
    {
        if (auditPlan is null)
            return BadRequest("AuditPlanForCreationDto object is null");

        var createdAuditPlan = _service.AuditPlanService.CreateAuditPlan(auditPlan);

        return CreatedAtRoute("AuditPlanById", new {id = createdAuditPlan.Id}, createdAuditPlan);
    }

    [HttpGet("collection/({ids})", Name = "CompanyCollection")]
    public IActionResult GetAuditPlanCollection(
        [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        var plans = _service.AuditPlanService.GetByIds(ids, trackChanges: false);

        return Ok(plans);
    }

    [HttpPost("collection")]
    public IActionResult CreateAuditPlanCollection([FromBody] IEnumerable<AuditPlanForCreationDto> planCollection)
    {
        var result = _service.AuditPlanService.CreateAuditPlanCollection(planCollection);

        return CreatedAtRoute("CompanyCollection", new {result.ids}, result.plans);
    }
}