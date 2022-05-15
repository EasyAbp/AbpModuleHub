using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using EasyAbp.AbpModuleHub.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.HubModules
{
    [Authorize(AbpModuleHubPermissions.HubModuleManagement.Management)]
    public class HubModuleManagementAppService : ApplicationService, IHubModuleManagementAppService
    {
        private readonly HubModuleManager _hubModuleManager;
        private readonly IHubModuleRepository _hubModuleRepository;

        public HubModuleManagementAppService(HubModuleManager hubModuleManager,
            IHubModuleRepository hubModuleRepository)
        {
            _hubModuleManager = hubModuleManager;
            _hubModuleRepository = hubModuleRepository;
        }

        [Authorize(AbpModuleHubPermissions.HubModuleManagement.Create)]
        public async Task<HubModuleDto> CreateModuleAsync(CreateHubModuleDto input)
        {
            var newModule = await _hubModuleManager.CreateModuleAsync(new CreateModuleInfo(
                input.Name,
                input.Description,
                input.PayMethod,
                input.Price,
                input.ModuleTypeId,
                input.CoverUrl,
                input.AuthorId));

            return ObjectMapper.Map<HubModule, HubModuleDto>(newModule);
        }

        [Authorize(AbpModuleHubPermissions.HubModuleManagement.Update)]
        public async Task UpdateModuleAsync(UpdateHubModuleDto input)
        {
            var module = await _hubModuleRepository.GetAsync(input.Id);
            module.UpdateBaseInfo(input.Name, input.Description, input.PayMethod);
            module.ModuleTypeId = input.ModuleTypeId;
            module.CoverUrl = input.CoverUrl;

            await _hubModuleRepository.UpdateAsync(module);
        }

        [Authorize(AbpModuleHubPermissions.HubModuleManagement.Delete)]
        public async Task DeleteModuleAsync(Guid id)
        {
            var module = await _hubModuleRepository.FindAsync(id);
            if (module == null)
            {
                return;
            }

            await _hubModuleManager.DeleteModuleAsync(module);
        }

        public async Task<HubModuleDto> GetModuleByIdAsync(Guid id)
        {
            return ObjectMapper.Map<HubModule, HubModuleDto>(await _hubModuleRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<HubModuleInListDto>> GetListAsync(PagedResultRequestDto input)
        {
            var totalCount = await _hubModuleRepository.GetCountAsync();
            var modules = await _hubModuleRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, "CreationTime desc", true);

            return new PagedResultDto<HubModuleInListDto>(totalCount,
                ObjectMapper.Map<List<HubModule>, List<HubModuleInListDto>>(modules));
        }
    }
}