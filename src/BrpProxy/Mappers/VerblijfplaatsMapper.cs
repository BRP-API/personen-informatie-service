using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Mappers;

public static class VerblijfplaatsMapper
{
    public static AbstractDatum? MapDatumVan(this GbaVerblijfplaats verblijfplaats)
    {
        return verblijfplaats switch
        {
            { DatumAanvangAdresBuitenland: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            { DatumAanvangAdreshouding: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            _ => null
        };
    }

    public static string? MapStraat(this GbaVerblijfplaats verblijfplaats)
    {
        return !string.IsNullOrWhiteSpace(verblijfplaats.NaamOpenbareRuimte)
            ? verblijfplaats.NaamOpenbareRuimte
            : verblijfplaats.Straat;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this GbaVerblijfplaatsBeperkt? verblijfplaats)
    {
        return verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999" ? true : null;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this GbaVerblijfplaats? verblijfplaats)
    {
        return verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999" ? true : null;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this GbaVerblijfplaatsBeperkt? verblijfplaats, AdresseringBeperkt adressering)
    {
        bool isInOnderzoek = (verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999");
        
        bool heeftAdresVelden = !string.IsNullOrEmpty(adressering.Adresregel1) || !string.IsNullOrEmpty(adressering.Adresregel2) || !string.IsNullOrEmpty(adressering.Adresregel3) || adressering.Land != null;

        return isInOnderzoek && heeftAdresVelden ? true : null;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this GbaVerblijfplaats? verblijfplaats, Adressering adressering)
    {
        bool isInOnderzoek = (verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999");

        bool heeftAdresVelden = !string.IsNullOrEmpty(adressering.Adresregel1) || !string.IsNullOrEmpty(adressering.Adresregel2) || !string.IsNullOrEmpty(adressering.Adresregel3) || adressering.Land != null;

        return isInOnderzoek && heeftAdresVelden ? true : null;
    }

}
