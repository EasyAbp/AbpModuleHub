using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public class ModuleManagementAppService : ApplicationService, IModuleManagementAppService
    {
        private readonly ModuleManager _moduleManager;
        private readonly IModuleRepository _moduleRepository;

        public ModuleManagementAppService(ModuleManager moduleManager,
            IModuleRepository moduleRepository)
        {
            _moduleManager = moduleManager;
            _moduleRepository = moduleRepository;
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
            return _moduleRepository.DeleteAsync(id);
        }

        public async Task<ModuleDto> GetModuleByIdAsync(Guid id)
        {
            return ObjectMapper.Map<ModuleProduct, ModuleDto>(await _moduleRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<ModuleListDto>> GetListAsync(PagedResultRequestDto input)
        {
            var totalCount = await _moduleRepository.GetCountAsync();
            var modules = await _moduleRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, "CreationTime desc");

            return new PagedResultDto<ModuleListDto>(totalCount,
                ObjectMapper.Map<List<ModuleProduct>, List<ModuleListDto>>(modules));
        }
    }
}