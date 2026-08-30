using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

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
            .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => src.Geboorte.Map()))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.KindInOnderzoek()))
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Naam.MapNaamGerelateerde()))
            ;
    }
}
