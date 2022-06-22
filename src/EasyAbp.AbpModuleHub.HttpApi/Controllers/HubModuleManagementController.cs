using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Controllers
{
    public class HubModuleManagementController : AbpModuleHubController, IHubModuleManagementAppService
    {
        private readonly IHubModuleManagementAppService _hubModuleManagementAppService;

        public HubModuleManagementController(IHubModuleManagementAppService hubModuleManagementAppService)
        {
            _hubModuleManagementAppService = hubModuleManagementAppService;
        }

        public Task<HubModuleDto> CreateModuleAsync(CreateHubModuleDto input) => _hubModuleManagementAppService.CreateModuleAsync(input);

        public Task UpdateModuleAsync(UpdateHubModuleDto input) => _hubModuleManagementAppService.UpdateModuleAsync(input);

        public Task DeleteModuleAsync(Guid id) => _hubModuleManagementAppService.DeleteModuleAsync(id);

        public Task<HubModuleDto> GetModuleByIdAsync(Guid id) => _hubModuleManagementAppService.GetModuleByIdAsync(id);

        public Task<PagedResultDto<HubModuleInListDto>> GetListAsync(PagedResultRequestDto input) => _hubModuleManagementAppService.GetListAsync(input);

        [HttpPut("/api/app/hub-module-management/approve-hub-module/{moduleId}")]
        public Task ApproveHubModuleAsync(Guid? moduleId) => _hubModuleManagementAppService.ApproveHubModuleAsync(moduleId);

        [HttpPut("/api/app/hub-module-management/reject-hub-module/{moduleId}")]
        public Task RejectHubModuleAsync(Guid? moduleId) => _hubModuleManagementAppService.RejectHubModuleAsync(moduleId);
    }
}