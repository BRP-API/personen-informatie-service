using AutoMapper;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class KindInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, KindInOnderzoek?>
{
    public KindInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, KindInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "090000" or
            "090100" or
            "090120" => new KindInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
