using EasyAbp.AbpModuleHub.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.AbpModuleHub.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpModuleHubController : AbpController
    {
        protected AbpModuleHubController()
        {
            LocalizationResource = typeof(AbpModuleHubResource);
        }
    }
}