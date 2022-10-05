using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuditController : BaseApiController
{
    private readonly AuditService _service;

    public AuditController(AuditService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Audit>>> GetAudits()
    {
        var audits = await _service.GetAuditsAsync();
        return Ok(audits);
    }

    [HttpPost("{id:guid}/Comment")]
    [Authorize]
    public async Task<ActionResult<Audit>> AddComment(Guid id, Comment newComment)
    {
        newComment.Id = Guid.NewGuid();

        var comment = await _service.AddCommentToAuditAsync(id, newComment);

        if (comment is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(AddComment), new {id = comment.Id}, comment);
    }

    [HttpGet("{id:guid}/Comment")]
    [Authorize]
    public async Task<ActionResult<Audit?>> GetAuditWithComments(Guid id)
    {
        var audit = await _service.GetAuditWithCommentsAsync(id);

        if (audit is null)
        {
            return NotFound();
        }

        return Ok(audit);
    }

    [HttpGet("{id:guid}/Schedule")]
    [Authorize]
    public async Task<ActionResult<Audit?>> GetAuditWithSchedules(Guid id)
    {
        var audit = await _service.GetAuditWithSchedulesAsync(id);

        if (audit is null)
        {
            return NotFound();
        }

        return Ok(audit);
    }

    [HttpPost("{id:guid}/Schedule")]
    [Authorize]
    public async Task<ActionResult<Schedule?>> AddScheduleToAudit(Guid id, Schedule newSchedule)
    {
        var schedule = await _service.AddScheduleToAuditAsync(id, newSchedule);

        if (schedule is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(AddScheduleToAudit), new {id = schedule.Id}, schedule);
    }
}