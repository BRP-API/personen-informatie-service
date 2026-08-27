using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class AangaanHuwelijkPartnerschapProfile : Profile
{
    public AangaanHuwelijkPartnerschapProfile()
    {
        CreateMap<BrpDtos.GbaAangaanHuwelijkPartnerschap, BrpApiDtos.AangaanHuwelijkPartnerschap>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            .ForMember(dest => dest.Land, opt =>
            {
                opt.PreCondition(src => src.Land?.Code != "0000");
                opt.MapFrom(src => src.Land);
            })
            .ForMember(dest => dest.Plaats, opt =>
            {
                opt.PreCondition(src => src.Plaats?.Code != "0000");
                opt.MapFrom(src => src.Plaats);
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.AangaanHuwelijkPartnerschapInOnderzoek()))
            ;
    }
}
