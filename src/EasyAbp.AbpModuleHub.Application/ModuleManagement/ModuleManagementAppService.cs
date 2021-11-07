using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public class ModuleManagementAppService : ApplicationService,IModuleManagementAppService
    {
        private readonly ModuleManager _moduleManager;

        public ModuleManagementAppService(ModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public async Task CreateModuleAsync(CreateModuleDto input)
        {
            await _moduleManager.CreateModuleAsync(new ModuleProduct(GuidGenerator.Create(),
                CurrentTenant.Id,
                input.Name,
                input.Description,
                input.PayMethod));
        }

        public Task UpdateModuleAsync(UpdateModuleDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteModuleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetModuleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ModuleDto>> GetListAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}