using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class NaamInOnderzoekExtensions
{
    public static void MapInOnderzoek(this BrpApiDtos.NaamGerelateerde? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamGerelateerdeInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.NaamPersoon? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.NaamPersoonBeperkt? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonBeperktInOnderzoek();
        }
    }

    private static BrpApiDtos.NaamPersoonInOnderzoek? MapNaamPersoonInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                AanduidingNaamgebruik = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010200" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010210" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010220" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010230" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010240" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010400" or "010410" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "016100" or "016110" => new BrpApiDtos.NaamPersoonInOnderzoek
            {
                AanduidingNaamgebruik = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }

    private static BrpApiDtos.NaamPersoonInOnderzoekBeperkt? MapNaamPersoonBeperktInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010200" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010210" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010220" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010230" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010240" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "010400" or
            "010410" => new BrpApiDtos.NaamPersoonInOnderzoekBeperkt
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}
