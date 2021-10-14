using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.AbpModuleHub.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpModuleHubDbContextFactory : IDesignTimeDbContextFactory<AbpModuleHubDbContext>
    {
        public AbpModuleHubDbContext CreateDbContext(string[] args)
        {
            AbpModuleHubEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpModuleHubDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpModuleHubDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyAbp.AbpModuleHub.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
