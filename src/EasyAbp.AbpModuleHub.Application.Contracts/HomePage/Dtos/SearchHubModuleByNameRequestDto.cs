using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.HomePage.Dtos
{
    public class SearchHubModuleByNameRequestDto : PagedResultRequestDto
    {
        public string SearchKey { get; set; }
    }
}