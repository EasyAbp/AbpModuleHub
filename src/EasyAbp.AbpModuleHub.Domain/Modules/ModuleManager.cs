using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.ProductDetails;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleManager : DomainService
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        private readonly ICurrentUser _currentUser;

        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IProductDetailRepository _productDetailRepository;

        private const string ModuleCategoryUniqueName = "AbpModuleHub.Module";
        private const string ModuleCategoryDisplayName = "模块";
        private const string DefaultProductGroupName = "Default";

        public ModuleManager(IProductManager productManager,
            ICategoryManager categoryManager,
            ICurrentUser currentUser,
            IStoreRepository storeRepository,
            ICategoryRepository categoryRepository,
            IModuleRepository moduleRepository,
            IProductDetailRepository productDetailRepository)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _currentUser = currentUser;
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _moduleRepository = moduleRepository;
            _productDetailRepository = productDetailRepository;
        }

        public async Task<ModuleProduct> CreateModuleAsync(ModuleProduct module)
        {
            var storeId = await EnsureStoreExistAsync();
            var categoryId = await EnsureProductCategoryExistAsync();

            var productDetail = await _productDetailRepository.InsertAsync(new ProductDetail(GuidGenerator.Create(),
                CurrentTenant.Id,
                storeId,
                module.Description));

            var productId = GuidGenerator.Create();
            await _productManager.CreateAsync(new Product(productId,
                    CurrentTenant.Id,
                    storeId,
                    DefaultProductGroupName,
                    productDetail.Id,
                    $"{ModuleCategoryUniqueName}.{productId}",
                    module.Name,
                    InventoryStrategy.NoNeed,
                    false,
                    true,
                    false,
                    null,
                    null,
                    0
                ),
                new[] { categoryId });

            module.BindProduct(productId);
            return await _moduleRepository.InsertAsync(module);
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

        public async Task DeleteModuleAsync(ModuleProduct module)
        {
            await _productManager.DeleteAsync(module.ProductId);
            await _moduleRepository.DeleteAsync(module.Id);
        }
    }
}