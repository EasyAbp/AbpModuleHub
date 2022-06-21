using System;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.Authors;

public class AuthorRepository : EfCoreRepository<AbpModuleHubDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(IDbContextProvider<AbpModuleHubDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}