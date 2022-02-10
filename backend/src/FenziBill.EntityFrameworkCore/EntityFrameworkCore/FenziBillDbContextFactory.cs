using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FenziBill.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class FenziBillDbContextFactory : IDesignTimeDbContextFactory<FenziBillDbContext>
{
    public FenziBillDbContext CreateDbContext(string[] args)
    {
        FenziBillEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FenziBillDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), ServerVersion.Parse("5.7"));

        return new FenziBillDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FenziBill.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
