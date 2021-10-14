using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.AbpModuleHub
{
    [DependsOn(
        typeof(AbpModuleHubEntityFrameworkCoreTestModule)
        )]
    public class AbpModuleHubDomainTestModule : AbpModule
    {

    }
}