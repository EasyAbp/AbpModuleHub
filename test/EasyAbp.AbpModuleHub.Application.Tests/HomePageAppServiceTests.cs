using System;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HomePage;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.Modules;
using Shouldly;
using Volo.Abp.Guids;
using Xunit;

namespace EasyAbp.AbpModuleHub;

public class HomePageAppServiceTests : AbpModuleHubApplicationTestBase
{
    private readonly IHomePageAppService _homePageAppService;

    public HomePageAppServiceTests()
    {
        InitializeDefaultModules().GetAwaiter().GetResult();
        
        _homePageAppService = GetRequiredService<IHomePageAppService>();
    }

    [Fact]
    public async Task Should_Return_Two_Modules()
    {
        var result = await _homePageAppService.SearchModuleByNameAsync(new SearchModuleByNameRequestDto
        {
            SearchKey = "Free Module",
            MaxResultCount = 10,
            SkipCount = 0
        });

        result.ShouldNotBeNull();
        result.Items.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);
    }

    private async Task InitializeDefaultModules()
    {
        var domainService = GetRequiredService<HubModuleManager>();
        var guidGenerator = GetRequiredService<IGuidGenerator>();

        await WithUnitOfWorkAsync(async () =>
        {
            // Todo: where is the Author repo?
            var authorId = guidGenerator.Create();
            
            await domainService.CreateModuleAsync(new CreateModuleInfo(
                "Free Module - A",
                "Free Module - A Description",
                "30",
                0,
                null,
                null,
                authorId));

            await domainService.CreateModuleAsync(new CreateModuleInfo(
                "Free Module - B",
                "Free Module - B Description",
                "20",
                0,
                null,
                null,
                authorId));
        });
    }
}