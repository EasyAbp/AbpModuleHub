using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.Authors;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.AbpModuleHub.EventHandles;

public class AuthorChangedEventHandler : ILocalEventHandler<EntityCreatedEventData<Author>>,
    ILocalEventHandler<EntityDeletedEventData<Author>>,
    ITransientDependency
{
    private readonly IStoreRepository _storeRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

    public AuthorChangedEventHandler(IStoreRepository storeRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant)
    {
        _storeRepository = storeRepository;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
    }

    public async Task HandleEventAsync(EntityCreatedEventData<Author> eventData)
    {
        await EnsureStoreCreateAsync(eventData.Entity);
    }

    public async Task HandleEventAsync(EntityDeletedEventData<Author> eventData)
    {
        await EnsureStoreDeleteAsync(eventData.Entity);
        throw new System.NotImplementedException();
    }

    #region > Store synchronization operations. <

    private async Task EnsureStoreCreateAsync(Author author)
    {
        await _storeRepository.InsertAsync(new Store(_guidGenerator.Create(),
            _currentTenant.Id,
            author.Name));
    }

    private async Task EnsureStoreDeleteAsync(Author author)
    {
        if (author.StoreId == null)
        {
            return;
        }

        var store = await _storeRepository.GetAsync(author.StoreId.Value);
        if (store != null)
        {
            await _storeRepository.DeleteAsync(store);
        }
    }

    #endregion
}