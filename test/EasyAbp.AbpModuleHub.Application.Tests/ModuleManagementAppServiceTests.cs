using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.HubModules.Dtos;
using EasyAbp.EShop.Products.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace EasyAbp.AbpModuleHub
{
    public class ModuleManagementAppServiceTests : AbpModuleHubApplicationTestBase
    {
        private readonly IHubModuleManagementAppService _hubModuleManagementAppService;

        public ModuleManagementAppServiceTests()
        {
            _hubModuleManagementAppService = GetRequiredService<IHubModuleManagementAppService>();
        }

        [Fact]
        public async Task Should_Deleted_Module()
        {
            // Insert new demo module.
            var newModule = await _hubModuleManagementAppService.CreateModuleAsync(new CreateHubModuleDto
            {
                Name = "Demo Module",
                CoverUrl = "https://www.image.com/cover.png",
                Description = "Demo Module Description",
                PayMethod = "20",
                Price = 100
            });

            // Call delete method.
            await _hubModuleManagementAppService.DeleteModuleAsync(newModule.Id);

            // Check if module is deleted.
            UsingDbContext(db =>
            {
                var module = db.ModuleProducts.FirstOrDefault(m => m.Id == newModule.Id);
                module.ShouldBeNull();

                UsingCustomDbContext<ProductsDbContext>(productsDbContext => productsDbContext.Products.Any().ShouldBeFalse());
            });
        }

        [Fact]
        public async Task Should_Created_Module()
        {
            await _hubModuleManagementAppService.CreateModuleAsync(new CreateHubModuleDto
            {
                Name = "DataDictionary Module",
                Description = "A DataDictionary Module.",
                CoverUrl = "https://www.picture.com/cover.png",
                ModuleTypeId = Guid.NewGuid(),
                PayMethod = "10",
                Price = 80
            });

            UsingDbContext(db =>
            {
                var module = db.ModuleProducts.FirstOrDefault(m => m.Name == "DataDictionary Module");
                module.ShouldNotBeNull();
                module.Name.ShouldBe("DataDictionary Module");
                module.Description.ShouldBe("A DataDictionary Module.");
                module.CoverUrl.ShouldBe("https://www.picture.com/cover.png");
                module.PayMethod.ShouldBe("10");

                UsingCustomDbContext<ProductsDbContext>(productsDbContext =>
                {
                    var product = productsDbContext.Products.FirstOrDefault(x => x.Id == module.ProductId);
                    product.ShouldNotBeNull();
                });
            });
        }

        [Fact]
        public async Task Should_Return_Module_Info()
        {
            var module = await _hubModuleManagementAppService.CreateModuleAsync(new CreateHubModuleDto
            {
                Name = "Details Module",
                Description = "A Details Module.",
                CoverUrl = "https://www.picture.com/cover.png",
                ModuleTypeId = Guid.NewGuid(),
                PayMethod = "99",
                Price = 50
            });

            var moduleDto = await _hubModuleManagementAppService.GetModuleByIdAsync(module.Id);
            module.ShouldNotBeNull();
            moduleDto.Id.ShouldBe(module.Id);
            moduleDto.Name.ShouldBe(module.Name);
            moduleDto.Description.ShouldBe(module.Description);
            moduleDto.CoverUrl.ShouldBe(module.CoverUrl);
            moduleDto.ModuleTypeId.ShouldBe(module.ModuleTypeId);
        }
    }
}