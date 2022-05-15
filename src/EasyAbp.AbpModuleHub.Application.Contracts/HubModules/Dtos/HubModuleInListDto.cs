using System;
using EasyAbp.AbpModuleHub.Authors;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HubModules.Dtos
{
    public class HubModuleInListDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? OriginalPrice { get; set; }
        
        public decimal Price { get; set; }
        
        public Guid ProductId { get; set; }
        
        public AuthorDto Author { get; set; }
    }
}