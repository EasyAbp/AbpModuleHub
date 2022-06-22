using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Products;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace EasyAbp.AbpModuleHub.HubModules;

public class ApprovalEventHandler : ILocalEventHandler<HubModuleApprovedEvent>,
    ILocalEventHandler<HubModuleRejectedEvent>,
    ITransientDependency
{
    private readonly IProductRepository _productRepository;

    public ApprovalEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task HandleEventAsync(HubModuleApprovedEvent eventData)
    {
        // TODO: Wait EShop Support.
        throw new NotImplementedException();
    }

    public Task HandleEventAsync(HubModuleRejectedEvent eventData)
    {
        // TODO: Wait EShop Support.
        throw new NotImplementedException();
    }
}