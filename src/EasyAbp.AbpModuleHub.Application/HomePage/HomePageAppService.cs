using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;
using EasyAbp.AbpModuleHub.HubModules;

namespace EasyAbp.AbpModuleHub.HomePage
{
    public class HomePageAppService : ApplicationService, IHomePageAppService
    {
        private readonly IHubModuleRepository _hubModuleRepository;

        public HomePageAppService(IHubModuleRepository hubModuleRepository)
        {
            _hubModuleRepository = hubModuleRepository;
        }

        public async Task<PagedResultDto<SearchHubModuleResultDto>> SearchModuleByNameAsync(SearchHubModuleByNameRequestDto input)
        {
            var queryable = await _hubModuleRepository.GetQueryableAsync();

            var modules = queryable
                .Where(m => m.Name.Contains(input.SearchKey))
                .OrderByDescending(module => module.LastModificationTime);

            var totalCount = await AsyncExecuter.LongCountAsync(modules);
            var modulesList = await AsyncExecuter.ToListAsync(modules);

            return new PagedResultDto<SearchHubModuleResultDto>(totalCount,
                ObjectMapper.Map<List<HubModule>, List<SearchHubModuleResultDto>>(modulesList));
        }
    }
}