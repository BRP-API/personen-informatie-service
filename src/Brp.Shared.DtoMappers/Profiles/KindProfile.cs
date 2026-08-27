using AutoMapper;

namespace Brp.Shared.DtoMappers.Profiles;

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
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.KindInOnderzoek()))
            ;
    }
}
