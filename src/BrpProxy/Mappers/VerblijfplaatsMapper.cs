using Brp.Shared.DtoMappers.Mappers;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Mappers;

public static class VerblijfplaatsMapper
{
    public static BrpApiDtos.AbstractDatum? MapDatumVan(this BrpDtos.GbaVerblijfplaats verblijfplaats)
    {
        return verblijfplaats switch
        {
            { DatumAanvangAdresBuitenland: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            { DatumAanvangAdreshouding: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            _ => null
        };
    }

    public static string? MapStraat(this BrpDtos.GbaVerblijfplaats verblijfplaats)
    {
        return !string.IsNullOrWhiteSpace(verblijfplaats.NaamOpenbareRuimte)
            ? verblijfplaats.NaamOpenbareRuimte
            : verblijfplaats.Straat;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this BrpDtos.GbaVerblijfplaatsBeperkt? verblijfplaats)
    {
        return verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999" ? true : null;
    }

    public static bool? MapVastgesteldVerblijftNietOpAdres(this BrpDtos.GbaVerblijfplaats? verblijfplaats)
    {
        return verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999" ? true : null;
    }
}
