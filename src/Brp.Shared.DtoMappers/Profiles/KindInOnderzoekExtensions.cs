using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class KindInOnderzoekExtensions
{
    public static BrpApiDtos.KindInOnderzoek? KindInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if(source == null)
        {
            return null;
        }

        return source?.AanduidingGegevensInOnderzoek switch
        {
            "090000" or
            "090100" or
            "090120" => new BrpApiDtos.KindInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
