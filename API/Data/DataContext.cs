using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DbSet<AuditPlan> AuditPlans => Set<AuditPlan>();
    public DbSet<Audit> Audits => Set<Audit>();
    public DbSet<CommentPage> CommentPages => Set<CommentPage>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Schedule> Schedules => Set<Schedule>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}