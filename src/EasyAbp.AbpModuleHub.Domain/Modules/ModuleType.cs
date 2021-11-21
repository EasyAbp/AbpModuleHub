using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleType : AggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        protected ModuleType()
        {
        }

        public ModuleType(Guid id,
            string name,
            string description,
            Guid? tenantId)
            : base(id)
        {
            Name = name;
            Description = description;
            TenantId = tenantId;
        }
    }
}