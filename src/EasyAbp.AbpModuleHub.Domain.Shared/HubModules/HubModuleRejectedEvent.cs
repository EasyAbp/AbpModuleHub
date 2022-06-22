using System;

namespace EasyAbp.AbpModuleHub.HubModules;

public class HubModuleRejectedEvent
{
    public Guid HubModuleId { get; set; }

    public Guid ProductId { get; set; }

    public HubModuleRejectedEvent(Guid hubModuleId, Guid productId)
    {
        HubModuleId = hubModuleId;
        ProductId = productId;
    }
}