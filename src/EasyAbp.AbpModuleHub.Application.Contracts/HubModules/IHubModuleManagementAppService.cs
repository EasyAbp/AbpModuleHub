using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public interface IHubModuleManagementAppService : IApplicationService
    {
        Task<HubModuleDto> CreateModuleAsync(CreateHubModuleDto input);

        Task UpdateModuleAsync(UpdateHubModuleDto input);

        Task DeleteModuleAsync(Guid id);

        Task<HubModuleDto> GetModuleByIdAsync(Guid id);

        Task<PagedResultDto<HubModuleInListDto>> GetListAsync(PagedResultRequestDto input);
    }
}