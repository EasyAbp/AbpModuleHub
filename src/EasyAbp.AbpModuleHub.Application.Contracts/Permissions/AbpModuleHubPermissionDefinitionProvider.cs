using EasyAbp.AbpModuleHub.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.AbpModuleHub.Permissions
{
    public class AbpModuleHubPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpModuleHubPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpModuleHubPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpModuleHubResource>(name);
        }
    }
}
