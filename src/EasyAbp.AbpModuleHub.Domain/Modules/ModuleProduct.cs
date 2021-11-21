using System;
using EasyAbp.EShop.Products.Products;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class ModuleProduct : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string CoverUrl { get; set; }

        public virtual string Description { get; protected set; }

        public virtual string PayMethod { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual Product Product { get; protected set; }

        public virtual Guid? ModuleTypeId { get; set; }

        protected ModuleProduct()
        {
        }

        public ModuleProduct(
            Guid id,
            Guid? tenantId,
            string name,
            string description,
            string payMethod
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Description = description;
            PayMethod = payMethod;
        }

        public void BindProduct(Guid productId)
        {
            ProductId = productId;
        }
    }
}