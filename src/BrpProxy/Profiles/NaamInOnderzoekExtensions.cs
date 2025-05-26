using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;
using NaamGerelateerde = Brp.Shared.DtoMappers.BrpApiDtos.NaamGerelateerde;
using NaamInOnderzoek = Brp.Shared.DtoMappers.BrpApiDtos.NaamInOnderzoek;

namespace BrpProxy.Profiles;

public static class NaamInOnderzoekExtensions
{
    public static void MapInOnderzoek(this NaamGerelateerde? dest, Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamGerelateerdeInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this NaamPersoon? dest, Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this NaamPersoonBeperkt? dest, Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapNaamPersoonBeperktInOnderzoek();
        }
    }

    private static NaamPersoonInOnderzoek? MapNaamPersoonInOnderzoek(this Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                AanduidingNaamgebruik = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010200" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010210" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010220" => new NaamPersoonInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010230" => new NaamPersoonInOnderzoek
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010240" => new NaamPersoonInOnderzoek
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010400" or "010410" => new NaamPersoonInOnderzoek
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "016100" or "016110" => new NaamPersoonInOnderzoek
            {
                AanduidingNaamgebruik = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }

    private static NaamPersoonInOnderzoekBeperkt? MapNaamPersoonBeperktInOnderzoek(this Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010200" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010210" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010220" => new NaamPersoonInOnderzoekBeperkt
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010230" => new NaamPersoonInOnderzoekBeperkt
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010240" => new NaamPersoonInOnderzoekBeperkt
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010400" or
            "010410" => new NaamPersoonInOnderzoekBeperkt
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }

    private static NaamInOnderzoek? MapNaamGerelateerdeInOnderzoek(this Brp.Shared.DtoMappers.BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "020000" or
            "020200" or
            "030000" or
            "030200" or
            "050000" or
            "050200" or
            "090000" or
            "090200" => new NaamInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "020210" or
            "030210" or
            "050210" or
            "090210" => new NaamInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "020220" or
            "030220" or
            "050220" or
            "090220" => new NaamInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "020230" or
            "030230" or
            "050230" or
            "090230" => new NaamInOnderzoek
            {
                Voorvoegsel = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "020240" or
            "030240" or
            "050240" or
            "090240" => new NaamInOnderzoek
            {
                Geslachtsnaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}
