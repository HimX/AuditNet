using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public DbSet<AuditPlan> AuditPlans => Set<AuditPlan>();
    public DbSet<Audit> Audits => Set<Audit>();
    public DbSet<CommentPage> CommentPages => Set<CommentPage>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<Person> Persons => Set<Person>();

    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>()
            .HasMany(p => p.Persons)
            .WithMany(p => p.Audits)
            .UsingEntity<AuditPerson>(
                j => j
                    .HasOne(ap => ap.Person)
                    .WithMany(pe => pe.AuditPersons)
                    .HasForeignKey(ap => ap.PersonId),
                j => j
                    .HasOne(ap => ap.Audit)
                    .WithMany(au => au.AuditPersons)
                    .HasForeignKey(ap => ap.AuditId),
                j =>
                {
                    j.HasKey(t => new {t.AuditId, t.PersonId});
                    j.HasIndex(ap => new {ap.AuditId, ap.PersonId})
                        .IsUnique();
                }
            );
        modelBuilder.Entity<Audit>()
            .Property("AuditPlanId")
            .IsRequired();
        
        modelBuilder.ApplyConfiguration(new AuditPlanConfiguration());
        modelBuilder.ApplyConfiguration(new AuditConfiguration());
    }
}