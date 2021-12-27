using AutoMapper;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;
using EasyAbp.AbpModuleHub.Modules;

namespace EasyAbp.AbpModuleHub
{
    public class AbpModuleHubApplicationAutoMapperProfile : Profile
    {
        public AbpModuleHubApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ModuleProduct, SearchModuleResultDto>()
                .ForMember(c => c.PublishedTime, o => o.MapFrom(c => c.CreationTime));
            CreateMap<ModuleProduct, ModuleListDto>();

            CreateMap<ModuleType, ModuleTypeDto>();
            CreateMap<ModuleTypeDto, ModuleType>();
        }
    }
}