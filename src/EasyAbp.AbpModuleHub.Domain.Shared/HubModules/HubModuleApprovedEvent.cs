using System;

namespace EasyAbp.AbpModuleHub.HubModules;

public class HubModuleApprovedEvent
{
    public Guid HubModuleId { get; set; }

    public Guid ProductId { get; set; }

    public HubModuleApprovedEvent(Guid hubModuleId, Guid productId)
    {
        HubModuleId = hubModuleId;
        ProductId = productId;
    }
}