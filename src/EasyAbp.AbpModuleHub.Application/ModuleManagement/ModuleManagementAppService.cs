using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public class ModuleManagementAppService : ApplicationService, IModuleManagementAppService
    {
        private readonly HubModuleManager _hubModuleManager;
        private readonly IHubModuleRepository _hubModuleRepository;

        public ModuleManagementAppService(HubModuleManager hubModuleManager,
            IHubModuleRepository hubModuleRepository)
        {
            _hubModuleManager = hubModuleManager;
            _hubModuleRepository = hubModuleRepository;
        }

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Create)]
        public async Task<ModuleDto> CreateModuleAsync(CreateModuleDto input)
        {
            var newModule = await _hubModuleManager.CreateModuleAsync(new CreateModuleInfo(
                input.Name,
                input.Description,
                input.PayMethod,
                input.Price,
                input.ModuleTypeId,
                input.CoverUrl,
                input.AuthorId));

            return ObjectMapper.Map<HubModule, ModuleDto>(newModule);
        }

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Update)]
        public async Task UpdateModuleAsync(UpdateModuleDto input)
        {
            var module = await _hubModuleRepository.GetAsync(input.Id);
            module.UpdateBaseInfo(input.Name, input.Description, input.PayMethod);
            module.ModuleTypeId = input.ModuleTypeId;
            module.CoverUrl = input.CoverUrl;

            await _hubModuleRepository.UpdateAsync(module);
        }

        [Authorize(AbpModuleHubPermissions.ModuleManagement.Delete)]
        public async Task DeleteModuleAsync(Guid id)
        {
            var module = await _hubModuleRepository.FindAsync(id);
            if (module == null)
            {
                return;
            }

            await _hubModuleManager.DeleteModuleAsync(module);
        }

        public async Task<ModuleDto> GetModuleByIdAsync(Guid id)
        {
            return ObjectMapper.Map<HubModule, ModuleDto>(await _hubModuleRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<ModuleInListDto>> GetListAsync(PagedResultRequestDto input)
        {
            var totalCount = await _hubModuleRepository.GetCountAsync();
            var modules = await _hubModuleRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, "CreationTime desc", true);

            return new PagedResultDto<ModuleInListDto>(totalCount,
                ObjectMapper.Map<List<HubModule>, List<ModuleInListDto>>(modules));
        }
    }
}