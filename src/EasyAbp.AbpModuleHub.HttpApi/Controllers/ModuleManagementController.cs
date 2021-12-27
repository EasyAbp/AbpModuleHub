using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Controllers
{
    public class ModuleManagementController : AbpModuleHubController, IModuleManagementAppService
    {
        private readonly IModuleManagementAppService _moduleManagementAppService;

        public ModuleManagementController(IModuleManagementAppService moduleManagementAppService)
        {
            _moduleManagementAppService = moduleManagementAppService;
        }

        public Task<ModuleDto> CreateModuleAsync(CreateModuleDto input) => _moduleManagementAppService.CreateModuleAsync(input);

        public Task UpdateModuleAsync(UpdateModuleDto input) => _moduleManagementAppService.UpdateModuleAsync(input);

        public Task DeleteModuleAsync(Guid id) => _moduleManagementAppService.DeleteModuleAsync(id);

        public Task<ModuleDto> GetModuleByIdAsync(Guid id) => _moduleManagementAppService.GetModuleByIdAsync(id);

        public Task<PagedResultDto<ModuleListDto>> GetListAsync(PagedResultRequestDto input) => _moduleManagementAppService.GetListAsync(input);
    }
}