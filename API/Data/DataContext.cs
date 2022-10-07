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
    public DbSet<Person> Persons => Set<Person>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>()
            .HasMany(p => p.Persons)
            .WithMany(p => p.Audits)
            .UsingEntity<PersonAudited>(
                j => j
                    .HasOne(pa => pa.Person)
                    .WithMany(p => p.PersonAudited)
                    .HasForeignKey(pa => pa.PersonId),
                j => j
                    .HasOne(pa => pa.Audit)
                    .WithMany(p => p.PersonAudited)
                    .HasForeignKey(pa => pa.AuditId),
                j => j.HasKey(t => new {t.AuditId, t.PersonId})
            );

        modelBuilder.Entity<Audit>()
            .HasMany(p => p.Persons)
            .WithMany(p => p.Audits)
            .UsingEntity<PersonAuditor>(
                j => j
                    .HasOne(pa => pa.Person)
                    .WithMany(p => p.PersonAuditors)
                    .HasForeignKey(pa => pa.PersonId),
                j => j
                    .HasOne(pa => pa.Audit)
                    .WithMany(p => p.PersonAuditors)
                    .HasForeignKey(pa => pa.AuditId),
                j => j.HasKey(t => new {t.AuditId, t.PersonId})
            );
    }
}