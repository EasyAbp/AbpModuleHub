using AutoMapper;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;
using EasyAbp.AbpModuleHub.SearchModule.Dtos;

namespace EasyAbp.AbpModuleHub
{
    public class AbpModuleHubApplicationAutoMapperProfile : Profile
    {
        public AbpModuleHubApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ModuleProduct, SearchModuleResultDto>();
            CreateMap<ModuleProduct, ModuleListDto>();
        }
    }
}