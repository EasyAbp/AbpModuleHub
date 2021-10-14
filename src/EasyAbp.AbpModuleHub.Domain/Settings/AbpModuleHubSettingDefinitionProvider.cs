using Volo.Abp.Settings;

namespace EasyAbp.AbpModuleHub.Settings
{
    public class AbpModuleHubSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpModuleHubSettings.MySetting1));
        }
    }
}
