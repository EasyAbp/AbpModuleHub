using System;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public class ModuleTypeManagementAppService : CrudAppService<HubModuleType, ModuleTypeDto, Guid>, IModuleTypeManagementAppService
    {
        public ModuleTypeManagementAppService(IRepository<HubModuleType, Guid> repository) : base(repository)
        {
        }
    }
}