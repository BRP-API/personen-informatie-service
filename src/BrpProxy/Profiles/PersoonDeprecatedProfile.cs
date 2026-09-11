using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated.Deprecated;
using HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using Adressering = Brp.Shared.DtoMappers.BrpApiDtos.Adressering;

namespace BrpProxy.Profiles;

public class PersoonDeprecatedProfile : Profile
{
    public PersoonDeprecatedProfile()
    {
        CreateMap<GbaGezagPersoonBeperkt, GezagPersoonBeperkt>()
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.PreCondition(src => src.OpschortingBijhouding == null ||
                                        src.OpschortingBijhouding.Reden?.Code != "O");
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .ForMember(dest => dest.Verificatie, opt => opt.MapFrom(src => src.Verificatie.Map()))
            .ForMember(dest => dest.Rni, opt => opt.MapFrom(src => src.Rni.Map()))
            .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => src.Geboorte.Map(src.PersoonInOnderzoek)))
            .ForMember(dest => dest.OpschortingBijhouding, opt => opt.MapFrom(src => src.OpschortingBijhouding.Map()))
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Naam.Map(src.Geslacht, src.PersoonInOnderzoek)))
            .ForMember(dest => dest.Gezag, opt => opt.MapFrom(src => src.Gezag.Map()))
            .AfterMap(PersoonProfile.PersoonBeperktAfterMap)
            ;

        CreateMap<GbaPersoonBeperkt, PersoonBeperkt>()
            .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd(src.OpschortingBijhouding)))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .ForMember(dest => dest.Verificatie, opt => opt.MapFrom(src => src.Verificatie.Map()))
            .ForMember(dest => dest.Rni, opt => opt.MapFrom(src => src.Rni.Map()))
            .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => src.Geboorte.Map(src.PersoonInOnderzoek)))
            .ForMember(dest => dest.OpschortingBijhouding, opt => opt.MapFrom(src => src.OpschortingBijhouding.Map()))
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Naam.Map(src.Geslacht, src.PersoonInOnderzoek)))
            .AfterMap(PersoonProfile.PersoonBeperktAfterMap)
            ;

        CreateMap<GbaPersoon, Persoon>()
            .BeforeMap(PersoonProfile.PersoonBeforeMap)
            .AfterMap(PersoonProfile.PersoonAfterMap)
            .ForMember(dest => dest.DatumEersteInschrijvingGBA, opt => opt.MapFrom(src => src.DatumEersteInschrijvingGBA.Map()))
            .ForMember(dest => dest.GeheimhoudingPersoonsgegevens, opt => opt.MapFrom(src => src.Geheimhouding()))
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.PreCondition(src => src.OpschortingBijhouding == null ||
                                        src.OpschortingBijhouding.Reden?.Code != "O");
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            })
            .ForMember(dest => dest.DatumInschrijvingInGemeente, opt => opt.MapFrom(src => src.DatumInschrijvingInGemeente.Map()))
            .ForMember(dest => dest.GemeenteVanInschrijving, opt =>
            {
                opt.Condition(src => src.GemeenteVanInschrijving?.Code != "0000");
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .ForMember(dest => dest.IndicatieGezagMinderjarige, opt => opt.MapFrom(src => src.IndicatieGezagMinderjarige))
            .ForMember(dest => dest.Verificatie, opt => opt.MapFrom(src => src.Verificatie.Map()))
            .ForMember(dest => dest.Rni, opt => opt.MapFrom(src => src.Rni.Map()))
            .ForMember(dest => dest.Verblijfstitel, opt => opt.MapFrom(src => src.Verblijfstitel.Map()))
            .ForMember(dest => dest.UitsluitingKiesrecht, opt => opt.MapFrom(src => src.UitsluitingKiesrecht.Map()))
            .ForMember(dest => dest.EuropeesKiesrecht, opt => opt.MapFrom(src => src.EuropeesKiesrecht.Map()))
            .ForMember(dest => dest.Immigratie, opt => opt.MapFrom(src => src.Immigratie.Map(src.Verblijfplaats)))
            .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => src.Geboorte.Map(src.PersoonInOnderzoek)))
            .ForMember(dest => dest.Overlijden, opt => opt.MapFrom(src => src.Overlijden.Map()))
            .ForMember(dest => dest.OpschortingBijhouding, opt => opt.MapFrom(src => src.OpschortingBijhouding.Map()))
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Naam.Map(src.Geslacht, src.PersoonInOnderzoek)))
            .ForMember(dest => dest.Partners, opt => opt.MapFrom(src => src.Partners.Map()))
            .ForMember(dest => dest.Ouders, opt => opt.MapFrom(src => src.Ouders.Map()))
            .ForMember(dest => dest.Kinderen, opt => opt.MapFrom(src => src.Kinderen.Map()))
            .ForMember(dest => dest.Nationaliteiten, opt => opt.MapFrom(src => src.Nationaliteiten.Map()))
            .ForMember(dest => dest.Verblijfplaats, opt => opt.MapFrom(src => src.Verblijfplaats.Map()))
            .ForMember(dest => dest.Gezag, opt => opt.MapFrom(src => src.Gezag.Map()))
            ;
    }
}
