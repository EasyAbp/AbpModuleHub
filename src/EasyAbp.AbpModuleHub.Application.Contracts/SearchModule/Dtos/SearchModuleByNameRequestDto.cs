using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.SearchModule.Dtos
{
    public class SearchModuleByNameRequestDto : PagedResultRequestDto
    {
        public string SearchKey { get; set; }
    }
}