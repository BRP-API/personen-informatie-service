using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class OntbondenPartnerInOnderzoekExtensions
{
    public static BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek? OntbondenPartnerInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if(source == null)
        {
            return null;
        }

        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" or
            "050700" or
            "050710" => new BrpApiDtos.OntbindingHuwelijkPartnerschapInOnderzoek
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}