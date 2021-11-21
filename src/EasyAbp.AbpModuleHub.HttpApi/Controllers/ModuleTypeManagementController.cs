using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Controllers
{
    public class ModuleTypeManagementController : AbpModuleHubController, IModuleTypeManagementAppService
    {
        private readonly IModuleTypeManagementAppService _moduleTypeManagementAppService;

        public ModuleTypeManagementController(IModuleTypeManagementAppService moduleTypeManagementAppService)
        {
            _moduleTypeManagementAppService = moduleTypeManagementAppService;
        }

        public Task<ModuleTypeDto> GetAsync(Guid id) => _moduleTypeManagementAppService.GetAsync(id);

        public Task<PagedResultDto<ModuleTypeDto>> GetListAsync(PagedAndSortedResultRequestDto input) =>
            _moduleTypeManagementAppService.GetListAsync(input);

        public Task<ModuleTypeDto> CreateAsync(ModuleTypeDto input) => _moduleTypeManagementAppService.CreateAsync(input);

        public Task<ModuleTypeDto> UpdateAsync(Guid id, ModuleTypeDto input) => _moduleTypeManagementAppService.UpdateAsync(id, input);

        public Task DeleteAsync(Guid id) => _moduleTypeManagementAppService.DeleteAsync(id);
    }
}