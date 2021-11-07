using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.Modules;
using EasyAbp.AbpModuleHub.SearchModule.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.SearchModule
{
    public class SearchModuleAppService : ApplicationService, ISearchModuleAppService
    {
        private readonly IModuleRepository _moduleRepository;

        public SearchModuleAppService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<PagedResultDto<SearchModuleResultDto>> SearchModuleByNameAsync(SearchModuleByNameRequestDto input)
        {
            var queryable = await _moduleRepository.GetQueryableAsync();

            var modules = queryable.WhereIf(!string.IsNullOrEmpty(input.SearchKey), module => module.Name.Contains(input.SearchKey))
                .OrderByDescending(module => module.LastModificationTime);

            var totalCount = modules.LongCount();
            var modulesList = modules.PageBy(input).ToList();

            return new PagedResultDto<SearchModuleResultDto>(totalCount,
                ObjectMapper.Map<List<ModuleProduct>, List<SearchModuleResultDto>>(modulesList));
        }
    }
}