using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class IndexModel : AbpModuleHubPageModel
    {
        public IReadOnlyList<ModuleInListDto> Modules { get; set; } = new List<ModuleInListDto>();

        private readonly IModuleManagementAppService _moduleManagementAppService;

        public IndexModel(
            IModuleManagementAppService moduleManagementAppService)
        {
            _moduleManagementAppService = moduleManagementAppService;
        }

        public async Task OnGetAsync()
        {
            Modules = (await _moduleManagementAppService.GetListAsync(new PagedResultRequestDto())).Items;
        }
    }
}