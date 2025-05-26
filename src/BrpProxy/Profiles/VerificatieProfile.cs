using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class VerificatieProfile : Profile
{
    public VerificatieProfile()
    {
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaVerificatie, Brp.Shared.DtoMappers.BrpApiDtos.Verificatie>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}
