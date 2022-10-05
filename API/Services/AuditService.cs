using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class AuditService
{
    private readonly DataContext _context;

    public AuditService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AuditPlan>> GetPlansAsync()
    {
        return await _context.AuditPlans
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<AuditPlan?> GetPlanByIdAsync(Guid id)
    {
        return await _context.AuditPlans
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<AuditPlan?> CreatePlanAsync(AuditPlan newPlan)
    {
        _context.AuditPlans.Add(newPlan);
        await _context.SaveChangesAsync();

        return newPlan;
    }

    public async Task DeletePlanByIdAsync(Guid id)
    {
        var planToDelete = await _context.AuditPlans.FindAsync(id);

        if (planToDelete is null) return;

        _context.AuditPlans.Remove(planToDelete);

        await _context.SaveChangesAsync();
    }

    public async Task<AuditPlan> GetAuditsByPlanIdAsync(Guid id)
    {
        var plan = await _context.AuditPlans
            .Include(p => p.Audits)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (plan is null)
        {
            throw new NullReferenceException("Plan does not exist");
        }

        return plan;
    }

    public async Task<Audit?> AddAuditToPlanAsync(Guid planId, Audit newAudit)
    {
        var plan = await _context.AuditPlans.FindAsync(planId);

        if (plan is null) return null;

        plan.Audits ??= new List<Audit>();
        plan.Audits.Add(newAudit);
        _context.Audits.Add(newAudit);
        await _context.SaveChangesAsync();

        return newAudit;
    }

    public async Task<IEnumerable<Audit>> GetAuditsAsync()
    {
        return await _context.Audits
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Audit?> GetAuditByIdAsync(Guid id)
    {
        return await _context.Audits
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Audit?> CreateAuditAsync(Audit newAudit)
    {
        _context.Audits.Add(newAudit);
        await _context.SaveChangesAsync();

        return newAudit;
    }

    public async Task<Comment?> AddCommentToAuditAsync(Guid auditId, Comment comment)
    {
        var audit = await _context.Audits
            .Include(p => p.CommentPage)
            .FirstOrDefaultAsync(p => p.Id == auditId);

        if (audit is null) return null;

        audit.CommentPage ??= new CommentPage();

        audit.CommentPage.Comments ??= new List<Comment>();
        comment.State = audit.State;
        audit.CommentPage.Comments.Add(comment);
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task<Audit?> GetAuditWithCommentsAsync(Guid id)
    {
        var audit = await _context.Audits
            .Include(p => p.CommentPage)
            .Include(p => p.CommentPage!.Comments)
            .FirstOrDefaultAsync(p => p.Id == id);

        return audit;
    }

    public async Task<Schedule?> AddScheduleToAuditAsync(Guid id, Schedule schedule)
    {
        var audit = await _context.Audits.FindAsync(id);

        if (audit is null) return null;

        audit.Schedules ??= new List<Schedule>();
        audit.Schedules.Add(schedule);
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        return schedule;
    }

    public async Task<Audit?> GetAuditWithSchedulesAsync(Guid id)
    {
        var audit = await _context.Audits
            .Include(p => p.Schedules)
            .FirstOrDefaultAsync(p => p.Id == id);

        return audit;
    }
}