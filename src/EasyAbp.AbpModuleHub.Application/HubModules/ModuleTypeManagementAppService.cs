using System;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public class ModuleTypeManagementAppService : CrudAppService<HubModuleType, ModuleTypeDto, Guid>, IModuleTypeManagementAppService
    {
        public ModuleTypeManagementAppService(IRepository<HubModuleType, Guid> repository) : base(repository)
        {
        }
    }
}