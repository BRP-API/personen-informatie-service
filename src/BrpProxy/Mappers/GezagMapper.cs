using BrpApiDtos = HaalCentraal.BrpProxy.Generated;
using BrpDtos = HaalCentraal.BrpProxy.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Mappers;

public static class GezagMapper
{
    public static ICollection<BrpApiDtos.Gezagsrelatie> Map(this ICollection<BrpDtos.Gezagsrelatie> source)
    {
        return source.Select(g => g.Map()).Where(g => g is not null).ToList()!;
    }

    public static BrpApiDtos.Gezagsrelatie? Map(this BrpDtos.Gezagsrelatie source)
    {
        return source switch
        {
            BrpDtos.EenhoofdigOuderlijkGezag gezag => gezag.Map(),
            BrpDtos.GezamenlijkOuderlijkGezag gezag => gezag.Map(),
            BrpDtos.GezamenlijkGezag gezag => gezag.Map(),
            BrpDtos.Voogdij gezag => gezag.Map(),
            BrpDtos.TijdelijkGeenGezag gezag => gezag.Map(),
            BrpDtos.GezagNietTeBepalen gezag => gezag.Map(),
            _ => null
        };
    }

    private static BrpApiDtos.Minderjarige Map(this BrpDtos.Minderjarige source)
    {
        return new BrpApiDtos.Minderjarige
        {
            Burgerservicenummer = source.Burgerservicenummer,
            Naam = source.Naam?.MapNaamVolledigeNaam(source.Geslacht),
            Leeftijd = source.Geboorte?.Datum.Map().Leeftijd(),
        };
    }

    private static BrpApiDtos.GezagOuder Map(this BrpDtos.GezagOuder source)
    {
        return new BrpApiDtos.GezagOuder
        {
            Burgerservicenummer = source.Burgerservicenummer,
            Naam = source.Naam?.MapNaamVolledigeNaam(source.Geslacht),
        };
    }

    private static BrpApiDtos.EenhoofdigOuderlijkGezag Map(this BrpDtos.EenhoofdigOuderlijkGezag source)
    {
        return new BrpApiDtos.EenhoofdigOuderlijkGezag
        {
            Minderjarige = source.Minderjarige.Map(),
            Ouder = source.Ouder.Map(),
            InOnderzoek = source.InOnderzoek
        };
    }

    private static BrpApiDtos.GezamenlijkOuderlijkGezag Map(this BrpDtos.GezamenlijkOuderlijkGezag source)
    {
        return new BrpApiDtos.GezamenlijkOuderlijkGezag
        {
            Minderjarige = source.Minderjarige.Map(),
            Ouders = [.. source.Ouders.Select(o => o.Map())],
            InOnderzoek = source.InOnderzoek
        };
    }

    private static BrpApiDtos.BekendeDerde Map(this BrpDtos.BekendeDerde source)
    {
        return new BrpApiDtos.BekendeDerde
        {
            Burgerservicenummer = source.Burgerservicenummer,
            Naam = source.Naam?.MapNaamVolledigeNaam(source.Geslacht),
        };
    }

    private static BrpApiDtos.Derde? Map(this BrpDtos.Derde source)
    {
        return source switch
        {
            BrpDtos.BekendeDerde derde => derde.Map(),
            BrpDtos.OnbekendeDerde => new BrpApiDtos.OnbekendeDerde(),
            _ => null
        };
    }

    private static BrpApiDtos.GezamenlijkGezag Map(this BrpDtos.GezamenlijkGezag source)
    {
        return new BrpApiDtos.GezamenlijkGezag
        {
            Minderjarige = source.Minderjarige.Map(),
            Ouder = source.Ouder.Map(),
            Derde = source.Derde.Map(),
            InOnderzoek = source.InOnderzoek
        };
    }

    private static BrpApiDtos.Voogdij Map(this BrpDtos.Voogdij source)
    {
        return new BrpApiDtos.Voogdij
        {
            Minderjarige = source.Minderjarige.Map(),
            Derden = [.. source.Derden.Select(d => d.Map())],
            InOnderzoek = source.InOnderzoek
        };
    }

    private static BrpApiDtos.TijdelijkGeenGezag Map(this BrpDtos.TijdelijkGeenGezag source)
    {
        return new BrpApiDtos.TijdelijkGeenGezag
        {
            Minderjarige = source.Minderjarige.Map(),
            Toelichting = source.Toelichting,
            InOnderzoek = source.InOnderzoek
        };
    }

    private static BrpApiDtos.GezagNietTeBepalen Map(this BrpDtos.GezagNietTeBepalen source)
    {
        return new BrpApiDtos.GezagNietTeBepalen
        {
            Minderjarige = source.Minderjarige.Map(),
            Toelichting = source.Toelichting,
            InOnderzoek = source.InOnderzoek
        };
    }
}
