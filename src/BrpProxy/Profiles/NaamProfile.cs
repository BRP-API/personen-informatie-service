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
            .AfterMap((src, dest) =>
            {
                dest.VolledigeNaam = src.VolledigeNaam(src.Geslacht);
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

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NaamInOnderzoek?>().ConvertUsing<NaamGerelateerdeInOnderzoekConverter>();

        CreateMap<GbaNaamPersoon, NaamPersoon>()
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .AfterMap((src, dest) =>
            {
                dest.VolledigeNaam = dest.VolledigeNaam(dest.Geslacht);
            })
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NaamPersoonInOnderzoekBeperkt?>().ConvertUsing<NaamPersoonInOnderzoekBeperktConverter>();
        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NaamPersoonInOnderzoek?>().ConvertUsing<NaamPersoonInOnderzoekConverter>();
    }
}
