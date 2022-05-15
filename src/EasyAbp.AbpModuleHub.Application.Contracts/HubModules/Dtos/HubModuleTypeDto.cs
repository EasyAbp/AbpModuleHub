using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public class HubModuleTypeDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}