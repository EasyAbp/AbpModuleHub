using EasyAbp.AbpModuleHub.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EasyAbp.AbpModuleHub.Blazor
{
    public abstract class AbpModuleHubComponentBase : AbpComponentBase
    {
        protected AbpModuleHubComponentBase()
        {
            LocalizationResource = typeof(AbpModuleHubResource);
        }
    }
}
