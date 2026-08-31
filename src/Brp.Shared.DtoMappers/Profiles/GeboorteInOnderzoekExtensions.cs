using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class GeboorteInOnderzoekExtensions
{
    public static void MapInOnderzoek(this BrpApiDtos.Geboorte? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapGeboorteInOnderzoek();
        }
    }

    public static void MapInOnderzoek(this BrpApiDtos.GeboorteBeperkt? dest, BrpDtos.InOnderzoek? source)
    {
        if (dest != null && source != null)
        {
            dest.InOnderzoek = source.MapGeboorteBeperktInOnderzoek();
        }
    }

    private static BrpApiDtos.GeboorteInOnderzoekBeperkt? MapGeboorteBeperktInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" or
            "010300" or
            "010310" => new BrpApiDtos.GeboorteInOnderzoekBeperkt
            {
                Datum = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };
    }
}
