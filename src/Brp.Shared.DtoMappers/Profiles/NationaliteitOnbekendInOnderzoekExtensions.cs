using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class NationaliteitOnbekendInOnderzoekExtensions
{
    public static BrpApiDtos.NationaliteitOnbekendInOnderzoek? NationaliteitOnbekendInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if (source == null)
        {
            return null;
        }

        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or "040510" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "046300" or "046310" => new BrpApiDtos.NationaliteitOnbekendInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null
        };
    }
}
