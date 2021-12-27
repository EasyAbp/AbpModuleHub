using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using EasyAbp.AbpModuleHub.Permissions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Create)]
        public async Task<ModuleDto> CreateModuleAsync(CreateModuleDto input)
        {
            var newModule = await _moduleManager.CreateModuleAsync(new ModuleProduct(GuidGenerator.Create(),
                CurrentTenant.Id,
                input.Name,
                input.Description,
                input.PayMethod)
            {
                ModuleTypeId = input.ModuleTypeId,
                CoverUrl = input.CoverUrl
            });

            return ObjectMapper.Map<ModuleProduct, ModuleDto>(newModule);
        }

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Update)]
        public async Task UpdateModuleAsync(UpdateModuleDto input)
        {
            var module = await _moduleRepository.GetAsync(input.Id);
            module.UpdateBaseInfo(input.Name, input.Description, input.PayMethod);
            module.ModuleTypeId = input.ModuleTypeId;
            module.CoverUrl = input.CoverUrl;

            await _moduleRepository.UpdateAsync(module);
        }

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Delete)]
        public async Task DeleteModuleAsync(Guid id)
        {
            var module = await _moduleRepository.FindAsync(id);
            if (module == null)
            {
                return;
            }

            await _moduleManager.DeleteModuleAsync(module);
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