using EasyAbp.AbpModuleHub.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpModuleHubAppService : ApplicationService
    {
        protected AbpModuleHubAppService()
        {
            LocalizationResource = typeof(AbpModuleHubResource);
        }
    }
}
