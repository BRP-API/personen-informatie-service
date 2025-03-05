using AutoMapper;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Profiles
{
    public class KindProfile : Profile
    {
        public KindProfile()
        {
            CreateMap<GbaKind, Kind>()
                .BeforeMap((src, dest) =>
                {
                    if (src.Naam != null || src.InOnderzoek != null)
                    {
                        src.Naam ??= new HaalCentraal.BrpProxy.Generated.Gba.NaamBasis();
                    }
                    if (src.Geboorte != null || src.InOnderzoek != null)
                    {
                        src.Geboorte ??= new GbaGeboorte();
                    }
                })
                .AfterMap((src, dest) =>
                {
                    if (dest.Naam != null && src.InOnderzoek != null)
                    {
                        dest.Naam.InOnderzoek = src.InOnderzoek.MapNaamGerelateerdeInOnderzoek();
                    }
                    if (dest.Geboorte != null && src.InOnderzoek != null)
                    {
                        dest.Geboorte.InOnderzoek = src.InOnderzoek.MapGeboorteInOnderzoek();
                    }
                });

            CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, KindInOnderzoek?>().ConvertUsing<KindInOnderzoekConverter>();
        }
    }
}
