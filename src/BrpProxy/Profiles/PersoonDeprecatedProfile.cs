using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated.Deprecated;
using HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using System.Collections.ObjectModel;

namespace BrpProxy.Profiles;

public static class PersoonDeprecatedMapper
{
    public static ICollection<GezagPersoonBeperkt> Map(this ICollection<GbaGezagPersoonBeperkt> src)
    {
        var retval = new Collection<GezagPersoonBeperkt>();
        foreach (var persoon in src)
        {
            if (persoon != null)
            {
                retval.Add(persoon.MapGezagPersoonBeperkt()!);
            }
        }
        return retval;
    }

    public static ICollection<PersoonBeperkt> Map(this ICollection<GbaPersoonBeperkt> src)
    {
        var retval = new Collection<PersoonBeperkt>();
        foreach (var persoon in src)
        {
            if (persoon != null)
            {
                retval.Add(persoon.MapPersoonBeperkt());
            }
        }
        return retval;
    }

    public static ICollection<Persoon> Map(this ICollection<GbaPersoon> src)
    {
        var retval = new Collection<Persoon>();
        foreach (var persoon in src)
        {
            if (persoon != null)
            {
                retval.Add(persoon.MapPersoon());
            }
        }
        return retval;
    }

    private static GezagPersoonBeperkt MapGezagPersoonBeperkt(this GbaGezagPersoonBeperkt src)
    {
        return new GezagPersoonBeperkt
        {
            Burgerservicenummer = src.Burgerservicenummer,
            Geboorte = src.Geboorte?.Map(src.PersoonInOnderzoek),
            GeheimhoudingPersoonsgegevens = src.GeheimhoudingPersoonsgegevens > 0 ? true : null,
            Geslacht = src.Geslacht,
            InOnderzoek = src.InOnderzoek(),
            Leeftijd = src.Geboorte?.Datum?.Map().Leeftijd(src.OpschortingBijhouding),
            Naam = src.Naam?.Map(src.Geslacht, src.PersoonInOnderzoek),
            OpschortingBijhouding = src.OpschortingBijhouding?.Map(),
            Adressering = src.Map(),
            Rni = src.Rni?.Map(),
            Verificatie = src.Verificatie?.Map(),
            Gezag = src.Gezag?.Map()
        };
    }

    public static PersoonBeperkt MapPersoonBeperkt(this GbaPersoonBeperkt src)
    {
        return new PersoonBeperkt
        {
            Burgerservicenummer = src.Burgerservicenummer,
            Geboorte = src.Geboorte?.Map(src.PersoonInOnderzoek),
            GeheimhoudingPersoonsgegevens = src.GeheimhoudingPersoonsgegevens > 0 ? true : null,
            Geslacht = src.Geslacht,
            InOnderzoek = src.InOnderzoek(),
            Leeftijd = src.Geboorte?.Datum?.Map().Leeftijd(src.OpschortingBijhouding),
            Naam = src.Naam?.Map(src.Geslacht, src.PersoonInOnderzoek),
            OpschortingBijhouding = src.OpschortingBijhouding?.Map(),
            Adressering = src.Map(),
            Rni = src.Rni?.Map(),
            Verificatie = src.Verificatie?.Map()
        };
    }

    public static Persoon MapPersoon(this GbaPersoon src)
    {
        return new Persoon
        {
            ANummer = src.ANummer,
            Burgerservicenummer = src.Burgerservicenummer,
            DatumEersteInschrijvingGBA = src.DatumEersteInschrijvingGBA?.Map(),
            GeheimhoudingPersoonsgegevens = src.GeheimhoudingPersoonsgegevens > 0 ? true : null,
            Geslacht = src.Geslacht,
            InOnderzoek = src.InOnderzoek(),
            UitsluitingKiesrecht = src.UitsluitingKiesrecht?.Map(),
            EuropeesKiesrecht = src.EuropeesKiesrecht?.Map(),
            Leeftijd = src.Geboorte?.Datum?.Map().Leeftijd(src.OpschortingBijhouding),
            Naam = src.Naam.Map(src.Geslacht, src.PersoonInOnderzoek),
            Nationaliteiten = src.Nationaliteiten?.Map(),
            Geboorte = src.Geboorte?.Map(src.PersoonInOnderzoek),
            OpschortingBijhouding = src.OpschortingBijhouding?.Map(),
            Overlijden = src.Overlijden?.Map(),
            Verblijfplaats = src.Verblijfplaats?.Map(),
            Immigratie = src.Immigratie.Map(src.Verblijfplaats),
            GemeenteVanInschrijving = src.GemeenteVanInschrijving?.Code != "0000" ? src.GemeenteVanInschrijving.Map() : null,
            DatumInschrijvingInGemeente = src.DatumInschrijvingInGemeente?.Map(),
            IndicatieCurateleRegister = src.IndicatieCurateleRegister,
            IndicatieGezagMinderjarige = src.IndicatieGezagMinderjarige,
            Gezag = src.Gezag?.Map(),
            Verblijfstitel = src.Verblijfstitel?.Map(),
            Kinderen = src.Kinderen?.Map(),
            Ouders = src.Ouders?.Map(),
            Partners = src.Partners?.Map(),
            Rni = src.Rni?.Map(),
            Verificatie = src.Verificatie?.Map(),
            Adressering = src.Map(),
        };
    }
}
