using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class AuditPlanRepository : IAuditPlanRepository
{
    private readonly DataContext _context;

    public AuditPlanRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<AuditPlan>> GetPlansAsync()
    {
        return await _context.AuditPlans.ToListAsync();
    }

    public async Task<AuditPlan?> GetPlanAsync(Guid? planId)
    {
        return await _context.AuditPlans
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == planId);
    }

    public async Task<int> AddPlanAsync(AuditPlan auditPlan)
    {
        _context.AuditPlans.Add(auditPlan);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeletePlanAsync(Guid? planId)
    {
        var plan = await _context.AuditPlans
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == planId);

        if (plan is null)
        {
            throw new NullReferenceException("Plan does not exist");
        }

        _context.AuditPlans.Remove(plan);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdatePlanAsync(AuditPlan auditPlan)
    {
        var plan = await _context.AuditPlans
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == auditPlan.Id);

        if (plan is null)
        {
            throw new NullReferenceException("Plan does not exist");
        }

        _context.AuditPlans.Update(plan);

        return await _context.SaveChangesAsync();
    }
}