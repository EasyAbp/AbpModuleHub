using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.Modules
{
    public interface IModuleTypeRepository : IRepository<ModuleType, Guid>
    {
    }
}