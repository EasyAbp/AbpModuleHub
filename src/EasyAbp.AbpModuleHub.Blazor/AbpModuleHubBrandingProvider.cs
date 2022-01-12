using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EasyAbp.AbpModuleHub.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpModuleHubBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpModuleHub";
    }
}
