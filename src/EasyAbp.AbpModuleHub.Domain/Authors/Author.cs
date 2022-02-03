using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.AbpModuleHub.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }
    }
}