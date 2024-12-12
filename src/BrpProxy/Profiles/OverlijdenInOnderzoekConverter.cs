using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class OverlijdenInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, OverlijdenInOnderzoek?>
{
    public OverlijdenInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, OverlijdenInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "060000" or
            "060800" => new OverlijdenInOnderzoek
            {
                Datum = true,
                Land = true,
                Plaats = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "060810" => new OverlijdenInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "060820" => new OverlijdenInOnderzoek
            {
                Plaats = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "060830" => new OverlijdenInOnderzoek
            {
                Land = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
