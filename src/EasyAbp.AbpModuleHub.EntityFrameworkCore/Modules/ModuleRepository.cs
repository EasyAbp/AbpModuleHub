using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleRepository : EfCoreRepository<AbpModuleHubDbContext, Module, Guid>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Module>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(x => x.Author)
                .Include(x => x.ModuleType);
        }
    }
}