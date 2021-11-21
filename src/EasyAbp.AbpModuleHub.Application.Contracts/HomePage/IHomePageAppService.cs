using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.AbpModuleHub.HomePage
{
    public interface IHomePageAppService : IApplicationService
    {
        Task<PagedResultDto<SearchModuleResultDto>> SearchModuleByNameAsync(SearchModuleByNameRequestDto input);
    }
}