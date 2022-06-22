using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.Authors;
using EasyAbp.EShop.Products.ProductDetails;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace EasyAbp.AbpModuleHub.HubModules;

// TODO: [Need discussion]I don't think this is a good way to do it, it splits up the logic.
public class HubModuleChangedEventHandler : ILocalEventHandler<EntityCreatedEventData<HubModule>>,
    ILocalEventHandler<EntityDeletedEventData<HubModule>>,
    ILocalEventHandler<EntityUpdatedEventData<HubModule>>,
    ITransientDependency
{
    private readonly IProductManager _productManager;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly ICurrentUser _currentUser;
    private readonly IAttributeOptionIdsSerializer _attributeOptionIdsSerializer;

    private readonly IAuthorStoreMappingRepository _authorStoreMappingRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IProductDetailRepository _productDetailRepository;

    public HubModuleChangedEventHandler(IProductManager productManager,
        ICurrentTenant currentTenant,
        IAuthorStoreMappingRepository authorStoreMappingRepository,
        IGuidGenerator guidGenerator,
        IStoreRepository storeRepository,
        ICurrentUser currentUser,
        IProductDetailRepository productDetailRepository,
        IAttributeOptionIdsSerializer attributeOptionIdsSerializer)
    {
        _productManager = productManager;
        _currentTenant = currentTenant;
        _authorStoreMappingRepository = authorStoreMappingRepository;
        _guidGenerator = guidGenerator;
        _storeRepository = storeRepository;
        _currentUser = currentUser;
        _productDetailRepository = productDetailRepository;
        _attributeOptionIdsSerializer = attributeOptionIdsSerializer;
    }

    public async Task HandleEventAsync(EntityCreatedEventData<HubModule> eventData)
    {
        var storeId = await EnsureStoreCreateAsync();
        await CreateProduct(eventData.Entity, storeId);
    }

    public async Task HandleEventAsync(EntityDeletedEventData<HubModule> eventData)
    {
        await _productManager.DeleteAsync(eventData.Entity.ProductId);
    }

    public Task HandleEventAsync(EntityUpdatedEventData<HubModule> eventData)
    {
        //TODO: Not implemented yet.
        return Task.CompletedTask;
    }

    private async Task CreateProduct(HubModule module, Guid storeId)
    {
        var detailsId = await EnsureCreateProductDetails(module, storeId);

        var product = new Product(module.ProductId,
            _currentTenant.Id,
            storeId,
            HubModuleConsts.DefaultProductGroupName,
            detailsId,
            $"{HubModuleConsts.HubModuleUniqueNamePrefix}.{module.ProductId}",
            module.Name,
            InventoryStrategy.NoNeed,
            false,
            false,
            false,
            null,
            null,
            0
        );

        await HandleProductSku(product);
        await _productManager.CreateAsync(product);
    }

    private async Task<Guid?> EnsureCreateProductDetails(HubModule module, Guid storeId)
    {
        if (string.IsNullOrEmpty(module.Description))
        {
            return null;
        }

        var productDetailId = _guidGenerator.Create();
        await _productDetailRepository.InsertAsync(new ProductDetail(productDetailId,
            _currentTenant.Id,
            storeId,
            module.Description));

        return productDetailId;
    }

    private async Task<Guid> EnsureStoreCreateAsync()
    {
        var mapping = await _authorStoreMappingRepository.FirstOrDefaultAsync(x => x.AuthorId == _currentUser.Id);
        if (mapping != null)
        {
            return mapping.StoreId;
        }

        var newStoreId = _guidGenerator.Create();

        await _storeRepository.InsertAsync(new Store(newStoreId,
            _currentTenant.Id,
            $"{_currentUser.Name}'s Store"));
        await _authorStoreMappingRepository.InsertAsync(new AuthorStoreMapping(_currentUser.GetId(), newStoreId));

        return newStoreId;
    }

    private async Task HandleProductSku(Product product)
    {
        var attribute = new ProductAttribute(_guidGenerator.Create(), "Standard", null);
        var attributeOption = new ProductAttributeOption(_guidGenerator.Create(), "Standard", null);

        attribute.ProductAttributeOptions.Add(attributeOption);

        product.ProductAttributes.Add(attribute);

        product.ProductSkus.Add(new ProductSku(_guidGenerator.Create(),
            await _attributeOptionIdsSerializer.SerializeAsync(new[] { attributeOption.Id }),
            "Annual", AbpModuleHubConsts.Currency, null, 0, 1, 10, null, null, null));
    }
}