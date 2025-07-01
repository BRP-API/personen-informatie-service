using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using Brp.Shared.DtoMappers.Profiles;
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
            .BeforeMap(PersoonProfile.PersoonBeperktBeforeMap)
            .AfterMap(PersoonProfile.PersoonBeperktAfterMap)
            ;

        CreateMap<GbaPersoonBeperkt, PersoonBeperkt>()
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.PreCondition(src => src.OpschortingBijhouding == null ||
                                        src.OpschortingBijhouding.Reden?.Code != "O");
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .BeforeMap(PersoonProfile.PersoonBeperktBeforeMap)
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
            ;
    }
}
