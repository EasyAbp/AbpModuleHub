using System;

namespace EasyAbp.AbpModuleHub.HubModules;

[Flags]
public enum HubModuleStatus
{
    Approved = 1,
    Rejected = 2
}