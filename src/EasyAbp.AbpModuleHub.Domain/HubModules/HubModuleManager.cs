using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.ProductDetails;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public class HubModuleManager : DomainService
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IAttributeOptionIdsSerializer _attributeOptionIdsSerializer;

        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHubModuleRepository _hubModuleRepository;
        private readonly IProductDetailRepository _productDetailRepository;

        private const string ModuleCategoryUniqueName = "AbpModuleHub.Module";
        private const string ModuleCategoryDisplayName = "模块";
        private const string DefaultProductGroupName = "Default";

        public HubModuleManager(
            IProductManager productManager,
            ICategoryManager categoryManager,
            IAttributeOptionIdsSerializer attributeOptionIdsSerializer,
            IStoreRepository storeRepository,
            ICategoryRepository categoryRepository,
            IHubModuleRepository hubModuleRepository,
            IProductDetailRepository productDetailRepository)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _attributeOptionIdsSerializer = attributeOptionIdsSerializer;
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _hubModuleRepository = hubModuleRepository;
            _productDetailRepository = productDetailRepository;
        }

        #region > Create Hub Module <

        public async Task<HubModule> CreateModuleAsync(CreateHubModuleInfo info)
        {
            var storeId = await EnsureStoreExistAsync();
            var categoryId = await EnsureProductCategoryExistAsync();

            var productDetail = await _productDetailRepository.InsertAsync(new ProductDetail(GuidGenerator.Create(),
                CurrentTenant.Id,
                storeId,
                info.Description));

            var productId = GuidGenerator.Create();
            var product = new Product(productId,
                CurrentTenant.Id,
                storeId,
                DefaultProductGroupName,
                productDetail.Id,
                $"{ModuleCategoryUniqueName}.{productId}",
                info.Name,
                InventoryStrategy.NoNeed,
                false,
                true,
                false,
                null,
                null,
                0
            );

            var attribute = new ProductAttribute(GuidGenerator.Create(), "Standard", null);
            var attributeOption = new ProductAttributeOption(GuidGenerator.Create(), "Standard", null);

            attribute.ProductAttributeOptions.Add(attributeOption);

            product.ProductAttributes.Add(attribute);

            product.ProductSkus.Add(new ProductSku(GuidGenerator.Create(),
                await _attributeOptionIdsSerializer.SerializeAsync(new[] { attributeOption.Id }), "Annual",
                AbpModuleHubConsts.Currency, null, 0, 1, 10, null, null, null));

            await _productManager.CreateAsync(product, new[] { categoryId });

            return await _hubModuleRepository.InsertAsync(new HubModule(GuidGenerator.Create(),
                    CurrentTenant.Id,
                    info.Name,
                    info.Description,
                    info.PayMethod,
                    info.Price,
                    productId,
                    info.ModuleTypeId,
                    info.AuthorId),
                true);
        }

        private async Task<Guid> EnsureStoreExistAsync()
        {
            var store = await _storeRepository.FirstOrDefaultAsync();

            if (store == null)
            {
                return (await _storeRepository.InsertAsync(new Store(GuidGenerator.Create(),
                        CurrentTenant.Id,
                        ModuleCategoryUniqueName)))
                    .Id;
            }

            return store.Id;
        }

        private async Task<Guid> EnsureProductCategoryExistAsync()
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(c => c.UniqueName == ModuleCategoryUniqueName);

            if (category == null)
            {
                return (await _categoryManager.CreateAsync(null,
                        ModuleCategoryUniqueName,
                        ModuleCategoryDisplayName,
                        ModuleCategoryDisplayName,
                        null,
                        false))
                    .Id;
            }

            return category.Id;
        }

        #endregion

        public async Task DeleteModuleAsync(HubModule hubModule)
        {
            await _productManager.DeleteAsync(hubModule.ProductId);
            await _hubModuleRepository.DeleteAsync(hubModule.Id);
        }
    }
}