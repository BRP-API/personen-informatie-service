using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class OntbondenPartnerInOnderzoekConverter : ITypeConverter<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, OntbindingHuwelijkPartnerschapInOnderzoek?>
{
    public OntbindingHuwelijkPartnerschapInOnderzoek? Convert(Brp.Shared.DtoMappers.BrpDtos.InOnderzoek source, OntbindingHuwelijkPartnerschapInOnderzoek? destination, ResolutionContext context)
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