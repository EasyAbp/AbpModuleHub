using System;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public class HubModuleTypeManagementAppService : CrudAppService<HubModuleType, HubModuleTypeDto, Guid>, IHubModuleTypeManagementAppService
    {
        public HubModuleTypeManagementAppService(IRepository<HubModuleType, Guid> repository) : base(repository)
        {
        }
    }
}