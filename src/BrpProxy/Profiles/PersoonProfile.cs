﻿using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using Adressering = Brp.Shared.DtoMappers.BrpApiDtos.Adressering;
using AdresseringBeperkt = Brp.Shared.DtoMappers.BrpApiDtos.AdresseringBeperkt;

namespace BrpProxy.Profiles;

public class PersoonProfile : Profile
{
    public PersoonProfile()
    {
        CreateMap<GbaGezagPersoonBeperkt, GezagPersoonBeperkt>()
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.PreCondition(src => src.OpschortingBijhouding == null ||
                                        src.OpschortingBijhouding.Reden?.Code != "O");
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .BeforeMap((src, dest) =>
            {
                if (src.PersoonInOnderzoek != null)
                {
                    src.Naam ??= new Brp.Shared.DtoMappers.CommonDtos.NaamBasis();

                    src.Geboorte ??= new Brp.Shared.DtoMappers.BrpDtos.GeboorteBasis();
                }
            })
            .AfterMap((src, dest) =>
            {
                if (src.Verblijfplaats != null)
                {
                    dest.Adressering = new AdresseringBeperkt
                    {
                        Adresregel1 = src.Verblijfplaats.Adresregel1(),
                        Adresregel2 = src.Verblijfplaats.Adresregel2(src.GemeenteVanInschrijving),
                        Adresregel3 = src.Verblijfplaats.Adresregel3(),
                        Land = src.Verblijfplaats.Land(),
                        InOnderzoek = src.AdresseringInOnderzoek(),
                    };

                    dest.Adressering.IndicatieVastgesteldVerblijftNietOpAdres = src.Verblijfplaats.IndicatieVastgesteldVerblijfNietOpAdres(dest.Adressering);
                }
                if (dest.Naam != null)
                {
                    dest.Naam.VolledigeNaam = dest.Naam.VolledigeNaam(src.Geslacht);
                }

                dest.Naam.MapInOnderzoek(src.PersoonInOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.PersoonInOnderzoek);
            })
            ;

        CreateMap<GbaPersoonBeperkt, PersoonBeperkt>()
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.PreCondition(src => src.OpschortingBijhouding == null ||
                                        src.OpschortingBijhouding.Reden?.Code != "O");
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek()))
            .BeforeMap((src, dest) =>
            {
                if (src.PersoonInOnderzoek != null)
                {
                    src.Naam ??= new Brp.Shared.DtoMappers.CommonDtos.NaamBasis();

                    src.Geboorte ??= new Brp.Shared.DtoMappers.BrpDtos.GeboorteBasis();
                }
            })
            .AfterMap((src, dest) =>
            {
                if (src.Verblijfplaats != null)
                {
                    dest.Adressering = new AdresseringBeperkt
                    {
                        Adresregel1 = src.Verblijfplaats.Adresregel1(),
                        Adresregel2 = src.Verblijfplaats.Adresregel2(src.GemeenteVanInschrijving),
                        Adresregel3 = src.Verblijfplaats.Adresregel3(),
                        Land = src.Verblijfplaats.Land(),
                        InOnderzoek = src.AdresseringInOnderzoek(),
                    };

                    dest.Adressering.IndicatieVastgesteldVerblijftNietOpAdres = src.Verblijfplaats.IndicatieVastgesteldVerblijfNietOpAdres(dest.Adressering);
                }
                if (dest.Naam != null)
                {
                    dest.Naam.VolledigeNaam = dest.Naam.VolledigeNaam(src.Geslacht);
                }

                dest.Naam.MapInOnderzoek(src.PersoonInOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.PersoonInOnderzoek);
            })
            ;

        CreateMap<GbaPersoon, Persoon>()
            .BeforeMap((src, dest) =>
            {
                if (src.Naam != null || src.PersoonInOnderzoek != null)
                {
                    src.Naam ??= new Brp.Shared.DtoMappers.BrpDtos.GbaNaamPersoon();
                    if(src.Partners != null)
                    {
                        src.Naam.Partners = src.Partners;
                    }
                }
                if (src.Geboorte != null || src.PersoonInOnderzoek != null)
                {
                    src.Geboorte ??= new Brp.Shared.DtoMappers.BrpDtos.GbaGeboorte();
                }
                if (src.Immigratie != null || src.Verblijfplaats != null)
                {
                    src.Immigratie ??= new Brp.Shared.DtoMappers.BrpDtos.GbaImmigratie();
                    src.Immigratie.InOnderzoek = src.Verblijfplaats?.InOnderzoek;
                }
            })
            .AfterMap((src, dest) =>
            {
                if (dest.Naam != null || src.Verblijfplaats != null)
                {
                    dest.Adressering = new Adressering
                    {
                        Aanhef = dest.Naam.Aanhef(src.Geslacht),
                        Aanschrijfwijze = dest.Naam.Aanschrijfwijze(src.Geslacht),
                        GebruikInLopendeTekst = dest.Naam.GebruikInLopendeTekst(src.Geslacht),

                        Adresregel1 = src.Verblijfplaats.Adresregel1(),
                        Adresregel2 = src.Verblijfplaats.Adresregel2(src.GemeenteVanInschrijving),
                        Adresregel3 = src.Verblijfplaats.Adresregel3(),
                        Land = src.Verblijfplaats.Land()
                    };
                }
                if (src.PersoonInOnderzoek != null ||
                    (src.Partners != null && src.Partners.Any(p => p.InOnderzoek != null)) ||
                    src.Verblijfplaats?.InOnderzoek != null)
                {
                    dest.Adressering ??= new Adressering();

                    dest.Adressering.InOnderzoek = src.AdresseringInOnderzoek();
                    dest.Adressering.IndicatieVastgesteldVerblijftNietOpAdres = src.Verblijfplaats.IndicatieVastgesteldVerblijfNietOpAdres(dest.Adressering);
                }

                if (dest.Naam != null)
                {
                    dest.Naam.VolledigeNaam = dest.Naam.VolledigeNaam(src.Geslacht);
                }
                dest.Naam.MapInOnderzoek(src.PersoonInOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.PersoonInOnderzoek);
            })
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
            .ForMember(dest => dest.Gezag, opt =>
            {
                opt.PreCondition(src => src.Gezag != null);
                opt.MapFrom(src => src.Gezag);
            })
            ;
    }
}
