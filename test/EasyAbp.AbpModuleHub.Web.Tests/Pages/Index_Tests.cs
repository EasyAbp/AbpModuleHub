using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EasyAbp.AbpModuleHub.Pages
{
    public class Index_Tests : AbpModuleHubWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
