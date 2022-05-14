using System;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.ModuleManagement
{
    public interface IModuleTypeManagementAppService : ICrudAppService<ModuleTypeDto, Guid>
    {
    }
}