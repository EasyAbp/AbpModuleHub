using System;
using EasyAbp.AbpModuleHub.Authors;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public class HubModule : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string CoverUrl { get; set; }

        public virtual string Description { get; protected set; }

        public virtual string PayMethod { get; protected set; }

        public virtual decimal? OriginalPrice { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public HubModuleStatus Status { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual Guid? ModuleTypeId { get; set; }

        [CanBeNull] public virtual HubModuleType HubModuleType { get; set; }

        public virtual Guid AuthorId { get; protected set; }

        public virtual Author Author { get; protected set; }

        protected HubModule()
        {
        }

        public HubModule(
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
            Status = HubModuleStatus.Rejected;
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

        public void Approve()
        {
            Status = HubModuleStatus.Approved;
            AddLocalEvent(new HubModuleApprovedEvent(Id, ProductId));
        }

        public void Reject()
        {
            Status = HubModuleStatus.Rejected;
            AddLocalEvent(new HubModuleRejectedEvent(Id, ProductId));
        }
    }
}