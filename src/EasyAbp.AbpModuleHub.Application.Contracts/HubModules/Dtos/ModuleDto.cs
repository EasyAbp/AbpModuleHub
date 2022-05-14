using System;
using EasyAbp.AbpModuleHub.Authors;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public class ModuleDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public decimal? OriginalPrice { get; set; }
        
        public decimal Price { get; set; }
        
        public Guid ProductId { get; set; }
        
        public Guid? ModuleTypeId { get; set; }

        public ModuleTypeDto ModuleType { get; set; }

        public Guid AuthorId { get; set; }

        public AuthorDto Author { get; set; }
    }
}