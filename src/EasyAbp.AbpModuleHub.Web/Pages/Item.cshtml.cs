using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class ItemModel : AbpModuleHubPageModel
    {
        private readonly IProductViewAppService _productViewAppService;
        private readonly IHubModuleManagementAppService _hubModuleManagementAppService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        public HubModuleDto HubModule { get; set; }
        
        public ProductViewDto Product { get; set; }

        public IReadOnlyList<HubModuleInListDto> RelatedModules { get; set; } = new List<HubModuleInListDto>();

        public ItemModel(
            IProductViewAppService productViewAppService,
            IHubModuleManagementAppService hubModuleManagementAppService)
        {
            _productViewAppService = productViewAppService;
            _hubModuleManagementAppService = hubModuleManagementAppService;
        }
        
        public virtual async Task<IActionResult> OnGetAsync()
        {
            try
            {
                HubModule = await _hubModuleManagementAppService.GetModuleByIdAsync(Id);
                Product = await _productViewAppService.GetAsync(HubModule.ProductId);
            }
            catch
            {
                return RedirectToPage("/Index");
            }
            
            RelatedModules = (await _hubModuleManagementAppService.GetListAsync(new PagedResultRequestDto
            {
                MaxResultCount = 3
            })).Items;

            return Page();
        }
    }
}