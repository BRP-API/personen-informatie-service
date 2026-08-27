using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class NationaliteitProfile : Profile
{
    public NationaliteitProfile()
    {
        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.AbstractNationaliteit?>().ConvertUsing<NationaliteitConverter>();

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.NationaliteitBekend>()
            .ForMember(dest => dest.Nationaliteit, opt => opt.MapFrom(src => src.Nationaliteit))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.NationaliteitInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.BehandeldAlsNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.BijzonderNederlanderschapInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.VastgesteldNietNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.BijzonderNederlanderschapInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.Staatloos>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.StaatloosInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaNationaliteit, BrpApiDtos.NationaliteitOnbekend>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.NationaliteitOnbekendInOnderzoek()))
            ;
    }
}
