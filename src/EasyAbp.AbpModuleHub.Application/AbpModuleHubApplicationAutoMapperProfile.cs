using AutoMapper;
using EasyAbp.AbpModuleHub.Authors;
using EasyAbp.AbpModuleHub.HomePage.Dtos;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.ModuleManagement.Dtos;

namespace EasyAbp.AbpModuleHub
{
    public class AbpModuleHubApplicationAutoMapperProfile : Profile
    {
        public AbpModuleHubApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<HubModule, SearchModuleResultDto>()
                .ForMember(c => c.PublishedTime, o => o.MapFrom(c => c.CreationTime));
            CreateMap<HubModule, ModuleDto>();
            CreateMap<HubModule, ModuleInListDto>();

            CreateMap<HubModuleType, ModuleTypeDto>();
            CreateMap<ModuleTypeDto, HubModuleType>();
            
            CreateMap<Author, AuthorDto>();
        }
    }
}