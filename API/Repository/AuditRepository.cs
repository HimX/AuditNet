using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class AuditRepository : IAuditRepository
{
    private readonly DataContext _context;

    public AuditRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Audit>> GetAuditsAsync()
    {
        return await _context.Audits.ToListAsync();
    }

    public async Task<Audit?> GetAuditAsync(Guid? auditId)
    {
        return await _context.Audits
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == auditId);
    }

    public async Task<int> AddAuditAsync(Audit audit)
    {
        _context.Audits.Add(audit);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAuditAsync(Guid? auditId)
    {
        var audit = await _context.Audits
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == auditId);

        if (audit is null)
        {
            throw new NullReferenceException("Audit does not exist");
        }

        _context.Audits.Remove(audit);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAuditAsync(Audit newAudit)
    {
        var audit = await _context.Audits
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == newAudit.Id);

        if (audit is null)
        {
            throw new NullReferenceException("Plan does not exist");
        }

        _context.Audits.Update(audit);

        return await _context.SaveChangesAsync();
    }
}