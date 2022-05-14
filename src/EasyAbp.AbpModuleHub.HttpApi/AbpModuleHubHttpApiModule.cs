using Localization.Resources.AbpUi;
using EasyAbp.AbpModuleHub.Localization;
using EasyAbp.EShop;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using EasyAbp.EShop.Orders;
using EasyAbp.EShop.Payments;
using EasyAbp.EShop.Products;
using EasyAbp.EShop.Stores;

namespace EasyAbp.AbpModuleHub
{
    [DependsOn(
        typeof(AbpModuleHubApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpSettingManagementHttpApiModule),
        typeof(EShopHttpApiModule)
    )]
    [DependsOn(typeof(EShopOrdersHttpApiModule))]
    [DependsOn(typeof(EShopPaymentsHttpApiModule))]
    [DependsOn(typeof(EShopProductsHttpApiModule))]
    [DependsOn(typeof(EShopStoresHttpApiModule))]
    public class AbpModuleHubHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpModuleHubResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
