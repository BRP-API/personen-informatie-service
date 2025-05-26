using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Profiles;

public class OverlijdenProfile : Profile
{
    public OverlijdenProfile()
    {
        CreateMap<BrpDtos.GbaOverlijden, BrpApiDtos.Overlijden>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            .ForMember(dest => dest.Land, opt =>
            {
                opt.PreCondition(src => src.Land?.Code != "0000");
                opt.MapFrom(src => src.Land);
            })
            .ForMember(dest => dest.Plaats, opt =>
            {
                opt.PreCondition(src => src.Plaats?.Code != "0000");
                opt.MapFrom(src => src.Plaats);
            })
            ;

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.OverlijdenInOnderzoek?>().ConvertUsing<OverlijdenInOnderzoekConverter>();
    }
}
