using EasyAbp.AbpModuleHub.Localization;
using EasyAbp.EShop;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using EasyAbp.EShop.Orders;
using EasyAbp.EShop.Payments;
using EasyAbp.EShop.Products;
using EasyAbp.EShop.Stores;

namespace EasyAbp.AbpModuleHub
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(EShopDomainSharedModule)
    )]
    [DependsOn(typeof(EShopOrdersDomainSharedModule))]
    [DependsOn(typeof(EShopPaymentsDomainSharedModule))]
    [DependsOn(typeof(EShopProductsDomainSharedModule))]
    [DependsOn(typeof(EShopStoresDomainSharedModule))]
    public class AbpModuleHubDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AbpModuleHubGlobalFeatureConfigurator.Configure();
            AbpModuleHubModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpModuleHubDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpModuleHubResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/AbpModuleHub");

                options.DefaultResourceType = typeof(AbpModuleHubResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpModuleHub", typeof(AbpModuleHubResource));
            });
        }
    }
}
