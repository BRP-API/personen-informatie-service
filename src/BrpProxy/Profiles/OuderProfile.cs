using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Profiles;

public class OuderProfile : Profile
{
    public OuderProfile()
    {
        CreateMap<GbaOuder, Ouder>()
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
            })
            .ForMember(dest => dest.DatumIngangFamilierechtelijkeBetrekking, opt => opt.MapFrom(src => src.DatumIngangFamilierechtelijkeBetrekking.Map()))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, OuderInOnderzoek?>().ConvertUsing<OuderInOnderzoekConverter>();
    }
}
