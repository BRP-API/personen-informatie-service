using AutoMapper;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class NaamProfile : Profile
{
    public NaamProfile()
    {
        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.NaamBasis, NaamPersoonBeperkt>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.NaamBasis, NaamGerelateerde>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
                opt.MapFrom(src => src.Geslachtsnaam);
            })
            ;

        CreateMap<GbaNaamPersoon, NaamPersoon>()
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            ;
    }
}
