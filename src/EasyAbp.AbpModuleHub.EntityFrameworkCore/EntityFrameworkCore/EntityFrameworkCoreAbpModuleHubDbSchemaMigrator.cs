using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.AbpModuleHub.Data;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.AbpModuleHub.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpModuleHubDbSchemaMigrator
        : IAbpModuleHubDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpModuleHubDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpModuleHubDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpModuleHubDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
