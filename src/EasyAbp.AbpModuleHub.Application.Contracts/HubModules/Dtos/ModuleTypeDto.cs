using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public class ModuleTypeDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}