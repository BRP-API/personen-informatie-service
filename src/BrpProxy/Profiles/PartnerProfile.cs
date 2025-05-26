using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;

namespace BrpProxy.Profiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaPartner, Partner>()
            .BeforeMap((src, dest) =>
            {
                if(src.InOnderzoek != null)
                {
                    src.Naam ??= new Brp.Shared.DtoMappers.CommonDtos.NaamBasis();

                    src.Geboorte ??= new Brp.Shared.DtoMappers.BrpDtos.GbaGeboorte();
                }
                if(src.AangaanHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.AangaanHuwelijkPartnerschap ??= new Brp.Shared.DtoMappers.BrpDtos.GbaAangaanHuwelijkPartnerschap();
                    src.AangaanHuwelijkPartnerschap.InOnderzoek = src.InOnderzoek;
                }
                if(src.OntbindingHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.OntbindingHuwelijkPartnerschap ??= new Brp.Shared.DtoMappers.BrpDtos.GbaOntbindingHuwelijkPartnerschap();
                    src.OntbindingHuwelijkPartnerschap.InOnderzoek = src.InOnderzoek;
                }
            })
            .AfterMap((src, dest) =>
            {
                dest.Naam.MapInOnderzoek(src.InOnderzoek);

                dest.Geboorte.MapInOnderzoek(src.InOnderzoek);
            })
            .ForMember(dest => dest.SoortVerbintenis, opt =>
            {
                opt.PreCondition(src => src.SoortVerbintenis?.Code != ".");
                opt.MapFrom(src => src.SoortVerbintenis);
            });

        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaAangaanHuwelijkPartnerschap, AangaanHuwelijkPartnerschap>()
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

        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaOntbindingHuwelijkPartnerschap, OntbindingHuwelijkPartnerschap>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;

        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, PartnerInOnderzoek?>().ConvertUsing<PartnerInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, OntbindingHuwelijkPartnerschapInOnderzoek?>().ConvertUsing<OntbondenPartnerInOnderzoekConverter>();
    }
}
