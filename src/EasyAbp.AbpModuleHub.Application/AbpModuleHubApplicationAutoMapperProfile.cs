using AutoMapper;
using EasyAbp.AbpModuleHub.Authors;
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

            CreateMap<Module, SearchModuleResultDto>()
                .ForMember(c => c.PublishedTime, o => o.MapFrom(c => c.CreationTime));
            CreateMap<Module, ModuleDto>();
            CreateMap<Module, ModuleInListDto>();

            CreateMap<ModuleType, ModuleTypeDto>();
            CreateMap<ModuleTypeDto, ModuleType>();
            
            CreateMap<Author, AuthorDto>();
        }
    }
}