using System.Threading.Tasks;
using EasyAbp.EShop.Products.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace EasyAbp.AbpModuleHub.HubModules;

public class ProductCategoryDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;
    private readonly ICategoryManager _categoryManager;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IGuidGenerator _guidGenerator;

    public ProductCategoryDataSeedContributor(ICurrentTenant currentTenant,
        ICategoryManager categoryManager,
        IGuidGenerator guidGenerator,
        ICategoryRepository categoryRepository)
    {
        _currentTenant = currentTenant;
        _categoryManager = categoryManager;
        _guidGenerator = guidGenerator;
        _categoryRepository = categoryRepository;
    }

    [UnitOfWork]
    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            // TODO: Maybe the DisplayName should be used as a multi-language resource.
            if (await _categoryRepository.FirstOrDefaultAsync(x => x.DisplayName == ProductCategoryConsts.Sdk) != null)
            {
                return;
            }

            var category = await _categoryManager.CreateAsync(null,
                _guidGenerator.Create().ToString(),
                ProductCategoryConsts.Sdk,
                null,
                null,
                false);

            await _categoryRepository.InsertAsync(category);
        }
    }
}