using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.Modules
{
    public interface IModuleRepository : IRepository<Module, Guid>
    {
        
    }
}