using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OuderProfile : Profile
{
    public OuderProfile()
    {
        CreateMap<BrpDtos.GbaOuder, BrpApiDtos.Ouder>()
            .BeforeMap((src, dest) =>
            {
                if (src.InOnderzoek == null) return;

                src.Naam ??= new CommonDtos.NaamBasis();

                src.Geboorte ??= new BrpDtos.GbaGeboorte();
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            })
            .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => src.Geboorte.Map()))
            .ForMember(dest => dest.DatumIngangFamilierechtelijkeBetrekking, opt => opt.MapFrom(src => src.DatumIngangFamilierechtelijkeBetrekking.Map()))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.OuderInOnderzoek()))
            .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Naam.MapNaamGerelateerde(src.InOnderzoek)))
            ;
    }
}
