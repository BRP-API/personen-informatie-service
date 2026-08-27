using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class NationaliteitInOnderzoekExtensions
{
    public static BrpApiDtos.NationaliteitBekendInOnderzoek? NationaliteitInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if(source == null)
        {
            return null;
        }

        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                Nationaliteit = true,
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "040500" or "040510" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                Nationaliteit = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            "046300" or "046310" => new BrpApiDtos.NationaliteitBekendInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()

            },
            _ => null
        };
    }
}
