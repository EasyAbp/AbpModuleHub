using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.EShop.Products.Products;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace EasyAbp.AbpModuleHub.EventHandles;

public class ModuleChangedEventHandler : ILocalEventHandler<EntityCreatedEventData<HubModule>>,
    ILocalEventHandler<EntityDeletedEventData<HubModule>>,
    ILocalEventHandler<EntityUpdatedEventData<HubModule>>,
    ITransientDependency
{
    private readonly IProductManager _productManager;

    public ModuleChangedEventHandler(IProductManager productManager)
    {
        _productManager = productManager;
    }

    public Task HandleEventAsync(EntityCreatedEventData<HubModule> eventData)
    {
        throw new System.NotImplementedException();
    }

    public Task HandleEventAsync(EntityDeletedEventData<HubModule> eventData)
    {
        throw new System.NotImplementedException();
    }

    public Task HandleEventAsync(EntityUpdatedEventData<HubModule> eventData)
    {
        throw new System.NotImplementedException();
    }
}