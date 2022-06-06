using System;
using EasyAbp.EShop.Products.Products;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace EasyAbp.AbpModuleHub;

public static class AbpModuleHubDomainObjectExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance
                .AddOrUpdate(new[] { typeof(Product), typeof(ProductEto), typeof(ProductView) },
                    x =>
                    {
                        x.AddOrUpdateProperty<Guid?>(AbpModuleHubConsts.ProductAuthorIdExtraPropertyName);
                        x.AddOrUpdateProperty<string>(AbpModuleHubConsts.ProductAuthorNameExtraPropertyName);
                        x.AddOrUpdateProperty<string>(AbpModuleHubConsts.ProductDescriptionExtraPropertyName);
                    });
        });
    }
}