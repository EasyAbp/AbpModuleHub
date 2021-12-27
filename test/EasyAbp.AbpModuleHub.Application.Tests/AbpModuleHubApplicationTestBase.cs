using System;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub
{
    public abstract class AbpModuleHubApplicationTestBase : AbpModuleHubTestBase<AbpModuleHubApplicationTestModule>
    {
        public void UsingDbContext(Action<AbpModuleHubDbContext> action)
        {
            using (var db = GetRequiredService<AbpModuleHubDbContext>())
            {
                action.Invoke(db);
            }
        }

        public void UsingCustomDbContext<TDbContext>(Action<TDbContext> action) where TDbContext : IDisposable
        {
            using (var db = GetRequiredService<TDbContext>())
            {
                action.Invoke(db);
            }
        }
    }
}