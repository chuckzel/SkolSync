using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BakaDB;

/// <summary>
/// Read-only EF Core DbContext for Bakalari database.
/// </summary>
/// <remarks>
/// The Read-only behavior is not foolproof, using a read-only database user is recommended.
/// </remarks>
public partial class BakalariContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ResolveConnectionString());
        }

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    private static string ResolveConnectionString()
    {
        var candidateFiles = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "appsettings.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")
        };

        foreach (var candidateFile in candidateFiles)
        {
            if (!File.Exists(candidateFile))
            {
                continue;
            }

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(candidateFile, optional: false, reloadOnChange: false)
                .Build();

            var connectionString = configuration.GetConnectionString("Bakalari");
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                return connectionString;
            }
        }

        throw new InvalidOperationException("Connection string 'ConnectionStrings:Bakalari' was not found in appsettings.json.");
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new InvalidOperationException("This DbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("This DbContext is read-only.");
    }
}
