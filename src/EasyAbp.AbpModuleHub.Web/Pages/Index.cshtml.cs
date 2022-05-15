using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class IndexModel : AbpModuleHubPageModel
    {
        public IReadOnlyList<HubModuleInListDto> Modules { get; set; } = new List<HubModuleInListDto>();

        private readonly IHubModuleManagementAppService _hubModuleManagementAppService;

        public IndexModel(
            IHubModuleManagementAppService hubModuleManagementAppService)
        {
            _hubModuleManagementAppService = hubModuleManagementAppService;
        }

        public async Task OnGetAsync()
        {
            Modules = (await _hubModuleManagementAppService.GetListAsync(new PagedResultRequestDto())).Items;
        }
    }
}