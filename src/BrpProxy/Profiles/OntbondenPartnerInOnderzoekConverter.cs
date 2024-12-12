using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class OntbondenPartnerInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, OntbindingHuwelijkPartnerschapInOnderzoek?>
{
    public OntbindingHuwelijkPartnerschapInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, OntbindingHuwelijkPartnerschapInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" or
            "050700" or
            "050710" => new OntbindingHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}