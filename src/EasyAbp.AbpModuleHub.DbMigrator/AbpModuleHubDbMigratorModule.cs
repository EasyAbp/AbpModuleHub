using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace EasyAbp.AbpModuleHub.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpModuleHubEntityFrameworkCoreModule),
        typeof(AbpModuleHubApplicationContractsModule)
        )]
    public class AbpModuleHubDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
