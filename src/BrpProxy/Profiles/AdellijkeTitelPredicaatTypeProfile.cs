using AutoMapper;
using Hc = Brp.Shared.DtoMappers.BrpDtos;
using Gba = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Profiles;

public class AdellijkeTitelPredicaatTypeProfile : Profile
{
    public AdellijkeTitelPredicaatTypeProfile()
    {
        CreateMap<Gba.AdellijkeTitelPredicaatType, Hc.AdellijkeTitelPredicaatType>()
            .ForMember(dest => dest.Soort, opt => opt.MapFrom(src => src.Soort))
            ;
    }
}
