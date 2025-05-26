using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class UitsluitingKiesrechtProfile : Profile
{
    public UitsluitingKiesrechtProfile()
    {
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaUitsluitingKiesrecht, Brp.Shared.DtoMappers.BrpApiDtos.UitsluitingKiesrecht>()
            .ForMember(dest => dest.Einddatum, opt => opt.MapFrom(src => src.Einddatum.Map()));
    }
}
