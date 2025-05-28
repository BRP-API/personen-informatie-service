using AutoMapper;
using BrpApiDtos = HaalCentraal.BrpProxy.Generated;
using BrpDtos = HaalCentraal.BrpProxy.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class GezagProfile : Profile
{
    public GezagProfile()
    {
        CreateMap<BrpDtos.Gezagsrelatie, BrpApiDtos.Gezagsrelatie?>().ConvertUsing<GezagConverter>();

        CreateMap<BrpDtos.EenhoofdigOuderlijkGezag, BrpApiDtos.EenhoofdigOuderlijkGezag>();
        CreateMap<BrpDtos.GezamenlijkOuderlijkGezag, BrpApiDtos.GezamenlijkOuderlijkGezag>();
        CreateMap<BrpDtos.GezamenlijkGezag, BrpApiDtos.GezamenlijkGezag>();
        CreateMap<BrpDtos.Voogdij, BrpApiDtos.Voogdij>();
        CreateMap<BrpDtos.TijdelijkGeenGezag, BrpApiDtos.TijdelijkGeenGezag>();
        CreateMap<BrpDtos.GezagNietTeBepalen, BrpApiDtos.GezagNietTeBepalen>();

        CreateMap<BrpDtos.GezagOuder, BrpApiDtos.GezagOuder>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            });
        CreateMap<BrpDtos.Minderjarige, BrpApiDtos.Minderjarige>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            })
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            });

        CreateMap<BrpDtos.Derde, BrpApiDtos.Derde?>().ConvertUsing<DerdeConverter>();

        CreateMap<BrpDtos.BekendeDerde, BrpApiDtos.BekendeDerde>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            })
            ;
        CreateMap<BrpDtos.OnbekendeDerde, BrpApiDtos.OnbekendeDerde>();
    }
}

public class GezagConverter : ITypeConverter<BrpDtos.Gezagsrelatie, BrpApiDtos.Gezagsrelatie?>
{
    public BrpApiDtos.Gezagsrelatie? Convert(BrpDtos.Gezagsrelatie source, BrpApiDtos.Gezagsrelatie? destination, ResolutionContext context)
    {
        return source switch
        {
            BrpDtos.EenhoofdigOuderlijkGezag => context.Mapper.Map<BrpApiDtos.EenhoofdigOuderlijkGezag>(source),
            BrpDtos.GezamenlijkOuderlijkGezag => context.Mapper.Map<BrpApiDtos.GezamenlijkOuderlijkGezag>(source),
            BrpDtos.GezamenlijkGezag => context.Mapper.Map<BrpApiDtos.GezamenlijkGezag>(source),
            BrpDtos.Voogdij => context.Mapper.Map<BrpApiDtos.Voogdij>(source),
            BrpDtos.TijdelijkGeenGezag => context.Mapper.Map<BrpApiDtos.TijdelijkGeenGezag>(source),
            BrpDtos.GezagNietTeBepalen => context.Mapper.Map<BrpApiDtos.GezagNietTeBepalen>(source),
            _ => null
        };
    }
}

public class DerdeConverter : ITypeConverter<BrpDtos.Derde, BrpApiDtos.Derde?>
{
    public BrpApiDtos.Derde? Convert(BrpDtos.Derde source, BrpApiDtos.Derde? destination, ResolutionContext context)
    {
        return source switch
        {
            BrpDtos.BekendeDerde => context.Mapper.Map<BrpApiDtos.BekendeDerde>(source),
            BrpDtos.OnbekendeDerde => context.Mapper.Map<BrpApiDtos.OnbekendeDerde>(source),
            _ => null
        };
    }
}
