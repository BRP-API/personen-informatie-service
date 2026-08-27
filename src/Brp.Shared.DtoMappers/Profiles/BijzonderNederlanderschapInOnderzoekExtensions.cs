using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class BijzonderNederlanderschapInOnderzoekExtensions
{
    public static BrpApiDtos.BijzonderNederlanderschapInOnderzoek? BijzonderNederlanderschapInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if (source == null)
        {
            return null;
        }

        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.BijzonderNederlanderschapInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or
            "040510" or
            "046500" or
            "046510" => new BrpApiDtos.BijzonderNederlanderschapInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            "046300" or "046310" => new BrpApiDtos.BijzonderNederlanderschapInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            _ => null
        };
    }
}
