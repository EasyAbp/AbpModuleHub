using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public class PurchasedModuleDetailDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime? ExpiredTime { get; set; }
    }
}