﻿using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;
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
}
