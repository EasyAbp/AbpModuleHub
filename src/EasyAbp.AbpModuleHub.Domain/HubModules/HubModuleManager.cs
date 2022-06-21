using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.AbpModuleHub.HubModules
{
    public class HubModuleManager : DomainService
    {
        private readonly IHubModuleRepository _hubModuleRepository;

        public HubModuleManager(IHubModuleRepository hubModuleRepository)
        {
            _hubModuleRepository = hubModuleRepository;
        }

        #region > Create Hub Module <

        public async Task<HubModule> CreateModuleAsync(CreateHubModuleInfo info)
        {
            var productId = GuidGenerator.Create();
            return await _hubModuleRepository.InsertAsync(new HubModule(GuidGenerator.Create(),
                    CurrentTenant.Id,
                    info.Name,
                    info.Description,
                    info.PayMethod,
                    info.Price,
                    productId,
                    info.ModuleTypeId,
                    info.AuthorId),
                true);
        }

        #endregion

        public async Task DeleteModuleAsync(HubModule hubModule)
        {
            await _hubModuleRepository.DeleteAsync(hubModule.Id);
        }
    }
}