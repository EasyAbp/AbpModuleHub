using System;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public interface IHubModuleTypeManagementAppService : ICrudAppService<HubModuleTypeDto, Guid>
    {
    }
}