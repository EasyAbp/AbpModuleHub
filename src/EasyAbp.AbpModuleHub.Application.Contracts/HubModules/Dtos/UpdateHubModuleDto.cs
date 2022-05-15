using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public class UpdateHubModuleDto : CreateOrUpdateHubModuleDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}