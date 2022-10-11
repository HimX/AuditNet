using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace API.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlite(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("API"));

        return new RepositoryContext(builder.Options);
    }
}