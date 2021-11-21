using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;

namespace EasyAbp.AbpModuleHub.HomePage
{
    public class HomePageAppService : ApplicationService, IHomePageAppService
    {
        private readonly IModuleRepository _moduleRepository;

        public HomePageAppService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<PagedResultDto<SearchModuleResultDto>> SearchModuleByNameAsync(SearchModuleByNameRequestDto input)
        {
            var queryable = await _moduleRepository.GetQueryableAsync();

            var modules = queryable
                .Where(m => m.Name.Contains(input.SearchKey))
                .OrderByDescending(module => module.LastModificationTime);

            var totalCount = await AsyncExecuter.LongCountAsync(modules);
            var modulesList = await AsyncExecuter.ToListAsync(modules);

            return new PagedResultDto<SearchModuleResultDto>(totalCount,
                ObjectMapper.Map<List<ModuleProduct>, List<SearchModuleResultDto>>(modulesList));
        }
    }
}