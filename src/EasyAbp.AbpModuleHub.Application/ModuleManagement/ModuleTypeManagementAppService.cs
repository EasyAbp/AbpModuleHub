using System;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public class ModuleTypeManagementAppService : CrudAppService<ModuleType, ModuleTypeDto, Guid>, IModuleTypeManagementAppService
    {
        public ModuleTypeManagementAppService(IRepository<ModuleType, Guid> repository) : base(repository)
        {
        }
    }
}