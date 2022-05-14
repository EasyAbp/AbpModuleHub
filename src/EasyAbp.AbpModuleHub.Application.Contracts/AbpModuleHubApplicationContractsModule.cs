using EasyAbp.EShop;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
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
        typeof(AbpModuleHubDomainSharedModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(EShopApplicationContractsModule)
    )]
    [DependsOn(typeof(EShopOrdersApplicationContractsModule))]
    [DependsOn(typeof(EShopPaymentsApplicationContractsModule))]
    [DependsOn(typeof(EShopProductsApplicationContractsModule))]
    [DependsOn(typeof(EShopStoresApplicationContractsModule))]
    public class AbpModuleHubApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpModuleHubDtoExtensions.Configure();
        }
    }
}
