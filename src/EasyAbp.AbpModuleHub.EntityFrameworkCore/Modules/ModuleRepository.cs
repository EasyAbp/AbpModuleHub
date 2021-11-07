using System;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleRepository : EfCoreRepository<AbpModuleHubDbContext, ModuleProduct, Guid>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}