using AutoMapper;
using BrpProxy.Mappers;
using NaamGerelateerde = Brp.Shared.DtoMappers.BrpApiDtos.NaamGerelateerde;
using Brp.Shared.DtoMappers.BrpApiDtos;

namespace BrpProxy.Profiles;

public class NaamProfile : Profile
{
    public NaamProfile()
    {
        CreateMap<Brp.Shared.DtoMappers.CommonDtos.NaamBasis, NaamPersoonBeperkt>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            ;

        CreateMap<Brp.Shared.DtoMappers.CommonDtos.NaamBasis, NaamGerelateerde>()
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
                opt.MapFrom(src => src.Geslachtsnaam);
            })
            ;

        CreateMap<Brp.Shared.DtoMappers.BrpDtos.GbaNaamPersoon, NaamPersoon>()
            .ForMember(dest => dest.Geslachtsnaam, opt =>
            {
                opt.PreCondition(src => src.Geslachtsnaam != ".");
            })
            .ForMember(dest => dest.Voorletters, opt => opt.MapFrom(src => src.Voorletters()))
            ;
    }
}
