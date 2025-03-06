using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Profiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<GbaPartner, Partner>()
            .BeforeMap((src, dest) =>
            {
                if(src.InOnderzoek != null)
                {
                    src.Naam ??= new HaalCentraal.BrpProxy.Generated.Gba.NaamBasis();

                    src.Geboorte ??= new GbaGeboorte();
                }
                if(src.AangaanHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.AangaanHuwelijkPartnerschap ??= new GbaAangaanHuwelijkPartnerschap();
                    src.AangaanHuwelijkPartnerschap.InOnderzoek = src.InOnderzoek;
                }
                if(src.OntbindingHuwelijkPartnerschap != null || src.InOnderzoek != null)
                {
                    src.OntbindingHuwelijkPartnerschap ??= new GbaOntbindingHuwelijkPartnerschap();
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

        CreateMap<GbaAangaanHuwelijkPartnerschap, AangaanHuwelijkPartnerschap>()
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

        CreateMap<GbaOntbindingHuwelijkPartnerschap, OntbindingHuwelijkPartnerschap>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, PartnerInOnderzoek?>().ConvertUsing<PartnerInOnderzoekConverter>();
        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, OntbindingHuwelijkPartnerschapInOnderzoek?>().ConvertUsing<OntbondenPartnerInOnderzoekConverter>();
    }
}
