using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.AbpModuleHub.Data
{
    /* This is used if database provider does't define
     * IAbpModuleHubDbSchemaMigrator implementation.
     */
    public class NullAbpModuleHubDbSchemaMigrator : IAbpModuleHubDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}