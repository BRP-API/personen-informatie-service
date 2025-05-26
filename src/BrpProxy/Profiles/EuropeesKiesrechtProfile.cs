using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Profiles;

public class EuropeesKiesrechtProfile : Profile
{
    public EuropeesKiesrechtProfile()
    {
        CreateMap<BrpDtos.GbaEuropeesKiesrecht, BrpApiDtos.EuropeesKiesrecht>()
            .ForMember(dest => dest.EinddatumUitsluiting, opt => opt.MapFrom(src => src.EinddatumUitsluiting.Map()));
    }
}
