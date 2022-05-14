using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EasyAbp.AbpModuleHub.MultiTenancy;
using EasyAbp.EShop;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
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
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AbpEmailingModule),
        typeof(EShopDomainModule)
    )]
    [DependsOn(typeof(EShopOrdersDomainModule))]
    [DependsOn(typeof(EShopPaymentsDomainModule))]
    [DependsOn(typeof(EShopProductsDomainModule))]
    [DependsOn(typeof(EShopStoresDomainModule))]
    public class AbpModuleHubDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
