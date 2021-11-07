using System;
using System.Threading.Tasks;
using Bogus;
using EasyAbp.AbpModuleHub.ModuleManagement;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.SearchModule;
using EasyAbp.AbpModuleHub.SearchModule.Dtos;
using Shouldly;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;
using Xunit;

namespace EasyAbp.AbpModuleHub.Debugger
{
    public class DemoDebugger : DebuggerBase
    {
        private readonly ISearchModuleAppService _searchModuleAppService;

        public DemoDebugger()
        {
            _searchModuleAppService = GetRequiredService<ISearchModuleAppService>();
        }

        [Fact]
        public async Task ModuleSearchTest()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var createModuleDto = new Faker<CreateModuleDto>()
                    .RuleFor(r => r.Name, r =>r.Commerce.ProductName())
                    .RuleFor(r => r.CoverUrl, r => r.Internet.Url())
                    .RuleFor(r => r.Price, r => r.System.Random.Double())
                    .RuleFor(r => r.PayMethod, r => "10")
                    .RuleFor(r => r.Description, r => r.Commerce.ProductName())
                    .Generate();

                var moduleManagement = GetRequiredService<IModuleManagementAppService>();
                await moduleManagement.CreateModuleAsync(createModuleDto);
            });
        }
    }
}