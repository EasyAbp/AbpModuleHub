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
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleManagement.Management);
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleManagement.Default, L("Permission:HubModule"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleManagement.Create, L("Permission:Create"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleManagement.Update, L("Permission:Update"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleManagement.Delete, L("Permission:Delete"));

            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleTypeManagement.Management);
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleTypeManagement.Default, L("Permission:HubModuleType"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleTypeManagement.Create, L("Permission:Create"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleTypeManagement.Update, L("Permission:Update"));
            myGroup.AddPermission(AbpModuleHubPermissions.HubModuleTypeManagement.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpModuleHubResource>(name);
        }
    }
}