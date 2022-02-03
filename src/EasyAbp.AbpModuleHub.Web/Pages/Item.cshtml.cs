using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class ItemModel : AbpModuleHubPageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly IModuleManagementAppService _moduleManagementAppService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        public ModuleDto Module { get; set; }
        
        public ProductDto Product { get; set; }

        public IReadOnlyList<ModuleInListDto> RelatedModules { get; set; } = new List<ModuleInListDto>();

        public ItemModel(
            IProductAppService productAppService,
            IModuleManagementAppService moduleManagementAppService)
        {
            _productAppService = productAppService;
            _moduleManagementAppService = moduleManagementAppService;
        }
        
        public virtual async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Module = await _moduleManagementAppService.GetModuleByIdAsync(Id);
                Product = await _productAppService.GetAsync(Module.ProductId);
            }
            catch
            {
                return RedirectToPage("/Index");
            }
            
            RelatedModules = (await _moduleManagementAppService.GetListAsync(new PagedResultRequestDto
            {
                MaxResultCount = 3
            })).Items;

            return Page();
        }
    }
}