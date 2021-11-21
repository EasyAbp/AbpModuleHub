using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.ModuleManagement.Dtos
{
    public class ModuleDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public Guid ModuleTypeId { get; set; }

        public string ModuleType { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}