using System.Threading.Tasks;
using Bogus;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using Xunit;

namespace EasyAbp.AbpModuleHub.Debugger
{
    public class DemoDebugger : DebuggerBase
    {
        public DemoDebugger()
        {
        }

        [Fact]
        public async Task ModuleSearchTest()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var createModuleDto = new Faker<CreateHubModuleDto>()
                    .RuleFor(r => r.Name, r =>r.Commerce.ProductName())
                    .RuleFor(r => r.CoverUrl, r => r.Internet.Url())
                    .RuleFor(r => r.Price, r => r.System.Random.Decimal())
                    .RuleFor(r => r.PayMethod, r => "10")
                    .RuleFor(r => r.Description, r => r.Commerce.ProductName())
                    .Generate();

                var moduleManagement = GetRequiredService<IHubModuleManagementAppService>();
                await moduleManagement.CreateModuleAsync(createModuleDto);
            });
        }
    }
}