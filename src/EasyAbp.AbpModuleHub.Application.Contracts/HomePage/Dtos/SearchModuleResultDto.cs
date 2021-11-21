using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HomePage.Dtos
{
    public class SearchModuleResultDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SupportFrontend { get; set; }

        public DateTime PublishedTime { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}