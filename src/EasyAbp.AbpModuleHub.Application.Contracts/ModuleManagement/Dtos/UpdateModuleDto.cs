using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public class UpdateModuleDto : CreateOrUpdateModuleDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}