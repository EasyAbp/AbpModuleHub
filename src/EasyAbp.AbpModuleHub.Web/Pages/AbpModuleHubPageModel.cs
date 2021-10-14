using EasyAbp.AbpModuleHub.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AbpModuleHubPageModel : AbpPageModel
    {
        protected AbpModuleHubPageModel()
        {
            LocalizationResourceType = typeof(AbpModuleHubResource);
        }
    }
}