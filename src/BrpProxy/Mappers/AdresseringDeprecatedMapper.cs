using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Mappers;

public static class AdresseringDeprecatedMapper
{
    public static AdresseringBeperkt? Map(this HaalCentraal.BrpProxy.Generated.Gba.Deprecated.GbaPersoonBeperkt src)
    {
        if (src == null)
        {
            return null;
        }
        var dest = new AdresseringBeperkt
        {
            Adresregel1 = src.Verblijfplaats.Adresregel1(),
            Adresregel2 = src.Verblijfplaats.Adresregel2(src.GemeenteVanInschrijving),
            Adresregel3 = src.Verblijfplaats.Adresregel3(),
            Land = src.Verblijfplaats.Land(),
            InOnderzoek = src.AdresseringInOnderzoek(),
        };

        dest.IndicatieVastgesteldVerblijftNietOpAdres = src.Verblijfplaats.IndicatieVastgesteldVerblijfNietOpAdres(dest);

        return dest;
    }

    public static Adressering? Map(this HaalCentraal.BrpProxy.Generated.Gba.Deprecated.GbaPersoon src)
    {
        if (src.Naam != null || src.Verblijfplaats != null ||
            src.PersoonInOnderzoek != null ||
            (src.Partners != null && src.Partners.Any(p => p.InOnderzoek != null)) ||
            src.Verblijfplaats?.InOnderzoek != null)
        {
            var naam = src.Naam?.Map(src.Geslacht, src.PersoonInOnderzoek);
            if (naam != null && src.Partners != null)
            {
                naam.Partners = src.Partners.Map();
            }
            var dest = new Adressering
            {
                Aanhef = naam?.Aanhef(src.Geslacht),
                Aanschrijfwijze = naam?.Aanschrijfwijze(src.Geslacht),
                GebruikInLopendeTekst = naam?.GebruikInLopendeTekst(src.Geslacht),

                Adresregel1 = src.Verblijfplaats.Adresregel1(),
                Adresregel2 = src.Verblijfplaats.Adresregel2(src.GemeenteVanInschrijving),
                Adresregel3 = src.Verblijfplaats.Adresregel3(),
                Land = src.Verblijfplaats.Land(),
                InOnderzoek = src.AdresseringInOnderzoek(),
            };
            dest.IndicatieVastgesteldVerblijftNietOpAdres = src.Verblijfplaats.IndicatieVastgesteldVerblijfNietOpAdres(dest);
            return dest;
        }
        return null;
    }
}
