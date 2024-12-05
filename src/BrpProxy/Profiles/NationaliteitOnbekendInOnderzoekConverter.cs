using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class NationaliteitOnbekendInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NationaliteitOnbekendInOnderzoek?>
{
    public NationaliteitOnbekendInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, NationaliteitOnbekendInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "040500" or "040510" => new NationaliteitOnbekendInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "046300" or "046310" => new NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}
