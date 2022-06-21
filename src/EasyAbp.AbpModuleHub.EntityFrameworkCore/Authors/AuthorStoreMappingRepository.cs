using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Authors;

public class AuthorStoreMappingRepository : EfCoreRepository<AbpModuleHubDbContext, AuthorStoreMapping>, IAuthorStoreMappingRepository
{
    public AuthorStoreMappingRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}