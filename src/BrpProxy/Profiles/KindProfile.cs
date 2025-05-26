using AutoMapper;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;
using CommonDtos = Brp.Shared.DtoMappers.CommonDtos;

namespace BrpProxy.Profiles;

public class KindProfile : Profile
{
    public KindProfile()
    {
        CreateMap<BrpDtos.GbaKind, BrpApiDtos.Kind>()
            .BeforeMap((src, dest) =>
            {
                if (src.InOnderzoek != null)
                {
                    src.Naam ??= new CommonDtos.NaamBasis();

                    src.Geboorte ??= new BrpDtos.GbaGeboorte();
                }
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            });

        CreateMap<BrpDtos.InOnderzoek, BrpApiDtos.KindInOnderzoek?>().ConvertUsing<KindInOnderzoekConverter>();
    }
}
