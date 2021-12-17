using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.EasyAbp.HomePage.Dtos
{
    public class ModuleDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string AuthorName { get; set; }
    }
}