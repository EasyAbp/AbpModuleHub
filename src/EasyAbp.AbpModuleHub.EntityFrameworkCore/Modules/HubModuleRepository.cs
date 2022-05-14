using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using EasyAbp.AbpModuleHub.HubModules;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class HubModuleRepository : EfCoreRepository<AbpModuleHubDbContext, HubModule, Guid>, IHubModuleRepository
    {
        public HubModuleRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<HubModule>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(x => x.Author)
                .Include(x => x.HubModuleType);
        }
    }
}