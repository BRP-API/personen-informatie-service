using AutoMapper;
using BrpApiDtos = Brp.Shared.DtoMappers.CommonDtos;
using BrpDtos = Brp.Shared.DtoMappers.CommonDtos;

namespace BrpProxy.Profiles;

public class AdellijkeTitelPredicaatTypeProfile : Profile
{
    public AdellijkeTitelPredicaatTypeProfile()
    {
        CreateMap<BrpDtos.AdellijkeTitelPredicaatType, BrpApiDtos.AdellijkeTitelPredicaatType>()
            .ForMember(dest => dest.Soort, opt => opt.MapFrom(src => src.Soort))
            ;
    }
}
