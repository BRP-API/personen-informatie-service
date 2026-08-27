using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class OntbindingHuwelijkPartnerschapProfile : Profile
{
    public OntbindingHuwelijkPartnerschapProfile()
    {
        CreateMap<BrpDtos.GbaOntbindingHuwelijkPartnerschap, BrpApiDtos.OntbindingHuwelijkPartnerschap>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.OntbondenPartnerInOnderzoek()))
            ;
    }
}
