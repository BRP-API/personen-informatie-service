﻿using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Mappers;

public static class PartnerMapper
{
    public static AangaanHuwelijkPartnerschapInOnderzoek? AangaanHuwelijkPartnerschapInOnderzoek(this HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" or
            "050600" => new AangaanHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                Land = true,
                Plaats = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "050610" => new AangaanHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "050620" => new AangaanHuwelijkPartnerschapInOnderzoek
            {
                Plaats = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "050630" => new AangaanHuwelijkPartnerschapInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
