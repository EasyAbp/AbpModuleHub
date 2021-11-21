using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HomePage;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.AbpModuleHub.Controllers
{
    public class HomePageController : AbpModuleHubController ,IHomePageAppService
    {
        private readonly IHomePageAppService _homePageAppService;

        public HomePageController(IHomePageAppService homePageAppService)
        {
            _homePageAppService = homePageAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<SearchModuleResultDto>> SearchModuleByNameAsync(SearchModuleByNameRequestDto input)
        {
            return _homePageAppService.SearchModuleByNameAsync(input);
        }
    }
}