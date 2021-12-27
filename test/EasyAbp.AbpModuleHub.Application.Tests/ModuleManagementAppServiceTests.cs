using EasyAbp.AbpModuleHub.ModuleManagement;
using Xunit;

namespace EasyAbp.AbpModuleHub
{
    public class ModuleManagementAppServiceTests : AbpModuleHubApplicationTestBase
    {
        private readonly IModuleManagementAppService _moduleManagementAppService;

        public ModuleManagementAppServiceTests()
        {
            _moduleManagementAppService = GetRequiredService<IModuleManagementAppService>();
        }
    }
}