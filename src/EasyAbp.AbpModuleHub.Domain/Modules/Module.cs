using System;
using EasyAbp.AbpModuleHub.Authors;
using EasyAbp.EShop.Products.Products;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.AbpModuleHub.Modules
{
    public class Module : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string CoverUrl { get; set; }

        public virtual string Description { get; protected set; }

        public virtual string PayMethod { get; protected set; }

        public virtual decimal? OriginalPrice { get; protected set; }
        
        public virtual decimal Price { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual Guid? ModuleTypeId { get; set; }
        
        [CanBeNull]
        public virtual ModuleType ModuleType { get; set; }
        
        public virtual Guid AuthorId { get; protected set; }

        public virtual Author Author { get; protected set; }

        protected Module()
        {
        }

        public Module(
            Guid id,
            Guid? tenantId,
            string name,
            string description,
            string payMethod,
            decimal price,
            Guid productId,
            Guid? moduleTypeId,
            Guid authorId
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Description = description;
            PayMethod = payMethod;
            Price = price;
            ProductId = productId;
            ModuleTypeId = moduleTypeId;
            AuthorId = authorId;
        }

        public void UpdateBaseInfo(
            string name,
            string description,
            string payMethod)
        {
            Name = name;
            Description = description;
            PayMethod = payMethod;
        }

        public void SetPrice(
            decimal? originalPrice,
            decimal price
        )
        {
            OriginalPrice = originalPrice;
            Price = price;
        }
    }
}