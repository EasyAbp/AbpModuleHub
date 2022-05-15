using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public class PurchasedHubModuleDetailDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime? ExpiredTime { get; set; }
    }
}