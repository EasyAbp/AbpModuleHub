using Volo.Abp.Modularity;

namespace EasyAbp.AbpModuleHub
{
    [DependsOn(
        typeof(AbpModuleHubApplicationModule),
        typeof(AbpModuleHubDomainTestModule)
        )]
    public class AbpModuleHubApplicationTestModule : AbpModule
    {

    }
}