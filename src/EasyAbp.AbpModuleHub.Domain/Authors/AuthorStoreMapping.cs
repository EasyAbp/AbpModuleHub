using System;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.AbpModuleHub.Authors;

public class AuthorStoreMapping : AggregateRoot
{
    public Guid AuthorId { get; set; }

    public Guid StoreId { get; set; }

    public override object[] GetKeys()
    {
        return new object[] { AuthorId, StoreId };
    }

    protected AuthorStoreMapping()
    {
    }

    public AuthorStoreMapping(Guid authorId, Guid storeId)
    {
        AuthorId = authorId;
        StoreId = storeId;
    }
}