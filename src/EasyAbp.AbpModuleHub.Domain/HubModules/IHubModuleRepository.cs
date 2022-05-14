using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public interface IHubModuleRepository : IRepository<HubModule, Guid>
    {
        
    }
}