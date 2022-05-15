using System;
using EasyAbp.AbpModuleHub.Authors;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public class HubModuleDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public decimal? OriginalPrice { get; set; }
        
        public decimal Price { get; set; }
        
        public Guid ProductId { get; set; }
        
        public Guid? ModuleTypeId { get; set; }

        public HubModuleTypeDto HubModuleType { get; set; }

        public Guid AuthorId { get; set; }

        public AuthorDto Author { get; set; }
    }
}