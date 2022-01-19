using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.AbpModuleHub.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpModuleHubBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ABP Module Hub";
    }
}
