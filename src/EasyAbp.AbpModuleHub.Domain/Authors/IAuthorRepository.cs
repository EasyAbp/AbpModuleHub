using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.AbpModuleHub.Authors;

public interface IAuthorRepository : IRepository<Author, Guid>
{
}