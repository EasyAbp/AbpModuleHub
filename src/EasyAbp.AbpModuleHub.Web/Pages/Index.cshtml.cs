using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class IndexModel : AbpModuleHubPageModel
    {
        public IReadOnlyList<ProductViewDto> Modules { get; set; } = new List<ProductViewDto>();

        private readonly IProductViewAppService _productViewAppService;

        public IndexModel(IProductViewAppService productViewAppService)
        {
            _productViewAppService = productViewAppService;
        }

        public async Task OnGetAsync()
        {
            Modules = (await _productViewAppService.GetListAsync(new GetProductListInput())).Items;
        }
    }
}