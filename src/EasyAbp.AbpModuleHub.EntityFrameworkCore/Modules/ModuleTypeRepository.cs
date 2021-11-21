using System;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleTypeRepository : EfCoreRepository<AbpModuleHubDbContext, ModuleType, Guid>, IModuleTypeRepository
    {
        public ModuleTypeRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}