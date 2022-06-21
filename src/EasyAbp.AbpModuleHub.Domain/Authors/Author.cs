using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.AbpModuleHub.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Avatar { get; set; }
        
        protected Author()
        {
        }

        public Author(
            Guid id,
            [NotNull] string name,
            [NotNull] string email,
            [CanBeNull] string avatar = null) : base(id)
        {
            Name = name;
            Email = email;
            Avatar = avatar;
        }
    }
}