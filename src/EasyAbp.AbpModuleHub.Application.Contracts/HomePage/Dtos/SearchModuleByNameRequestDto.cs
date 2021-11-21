using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HomePage.Dtos
{
    public class SearchModuleByNameRequestDto : PagedResultRequestDto
    {
        public string SearchKey { get; set; }
    }
}