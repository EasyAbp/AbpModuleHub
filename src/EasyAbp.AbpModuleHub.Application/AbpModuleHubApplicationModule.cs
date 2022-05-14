using EasyAbp.EShop;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using EasyAbp.EShop.Orders;
using EasyAbp.EShop.Payments;
using EasyAbp.EShop.Products;
using EasyAbp.EShop.Stores;

namespace EasyAbp.AbpModuleHub
{
    [DependsOn(
        typeof(AbpModuleHubDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpModuleHubApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(EShopApplicationModule)
    )]
    [DependsOn(typeof(EShopOrdersApplicationModule))]
    [DependsOn(typeof(EShopPaymentsApplicationModule))]
    [DependsOn(typeof(EShopProductsApplicationModule))]
    [DependsOn(typeof(EShopStoresApplicationModule))]
    public class AbpModuleHubApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpModuleHubApplicationModule>();
            });
        }
    }
}
