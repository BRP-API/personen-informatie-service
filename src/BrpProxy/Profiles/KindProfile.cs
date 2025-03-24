using AutoMapper;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Profiles;

public class KindProfile : Profile
{
    public KindProfile()
    {
        CreateMap<GbaKind, Kind>()
            .BeforeMap((src, dest) =>
            {
                if (src.InOnderzoek != null)
                {
                    src.Naam ??= new HaalCentraal.BrpProxy.Generated.Gba.NaamBasis();

                    src.Geboorte ??= new GbaGeboorte();
                }
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            });

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, KindInOnderzoek?>().ConvertUsing<KindInOnderzoekConverter>();
    }
}
