using System;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public abstract class CreateOrUpdateHubModuleDto
    {
        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public string PayMethod { get; set; }

        public decimal Price { get; set; }

        public Guid? ModuleTypeId { get; set; }
        
        public Guid AuthorId { get; set; }
    }
}