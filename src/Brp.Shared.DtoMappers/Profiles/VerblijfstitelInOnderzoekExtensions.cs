using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public static class VerblijfstitelInOnderzoekExtensions
{
    public static BrpApiDtos.VerblijfstitelInOnderzoek? VerblijfstitelInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if (source == null)
        {
            return null;
        }

        BrpApiDtos.VerblijfstitelInOnderzoek? retval = source.AanduidingGegevensInOnderzoek switch
        {
            "100000" or "103900" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding = true,
                DatumIngang = true,
                DatumEinde = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103910" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103920" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumEinde = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103930" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumIngang = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };

        return retval;
    }
}
