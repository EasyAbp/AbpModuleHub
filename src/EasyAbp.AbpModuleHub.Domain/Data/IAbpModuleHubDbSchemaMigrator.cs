using System.Threading.Tasks;

namespace EasyAbp.AbpModuleHub.Data
{
    public interface IAbpModuleHubDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
