using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class VerblijfstitelInOnderzoekConverter : ITypeConverter<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfstitelInOnderzoek?>
{
    public VerblijfstitelInOnderzoek? Convert(Brp.Shared.DtoMappers.BrpDtos.InOnderzoek source, VerblijfstitelInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "100000" or "103900" => new VerblijfstitelInOnderzoek
            {
                Aanduiding= true,
                DatumIngang= true,
                DatumEinde= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "103910" => new VerblijfstitelInOnderzoek
            {
                Aanduiding= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "103920" => new VerblijfstitelInOnderzoek
            {
                DatumEinde= true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "103930" => new VerblijfstitelInOnderzoek
            {
                DatumIngang = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
