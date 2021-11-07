using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.SearchModule.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.SearchModule
{
    public interface ISearchModuleAppService : IApplicationService
    {
        Task<PagedResultDto<SearchModuleResultDto>> SearchModuleByNameAsync(SearchModuleByNameRequestDto input);
    }
}