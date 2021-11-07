using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public interface IModuleManagementAppService : IApplicationService
    {
        Task CreateModuleAsync(CreateModuleDto input);

        Task UpdateModuleAsync(UpdateModuleDto input);

        Task DeleteModuleAsync(Guid id);

        Task GetModuleByIdAsync(Guid id);

        Task<PagedResultDto<ModuleDto>> GetListAsync(PagedResultRequestDto input);
    }
}