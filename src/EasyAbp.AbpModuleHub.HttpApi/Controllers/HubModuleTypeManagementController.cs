using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Controllers
{
    public class HubModuleTypeManagementController : AbpModuleHubController, IHubModuleTypeManagementAppService
    {
        private readonly IHubModuleTypeManagementAppService _hubModuleTypeManagementAppService;

        public HubModuleTypeManagementController(IHubModuleTypeManagementAppService hubModuleTypeManagementAppService)
        {
            _hubModuleTypeManagementAppService = hubModuleTypeManagementAppService;
        }

        public Task<HubModuleTypeDto> GetAsync(Guid id) => _hubModuleTypeManagementAppService.GetAsync(id);

        public Task<PagedResultDto<HubModuleTypeDto>> GetListAsync(PagedAndSortedResultRequestDto input) =>
            _hubModuleTypeManagementAppService.GetListAsync(input);

        public Task<HubModuleTypeDto> CreateAsync(HubModuleTypeDto input) => _hubModuleTypeManagementAppService.CreateAsync(input);

        public Task<HubModuleTypeDto> UpdateAsync(Guid id, HubModuleTypeDto input) => _hubModuleTypeManagementAppService.UpdateAsync(id, input);

        public Task DeleteAsync(Guid id) => _hubModuleTypeManagementAppService.DeleteAsync(id);
    }
}