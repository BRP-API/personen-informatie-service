using AutoMapper;
using BrpApiDtos = HaalCentraal.BrpProxy.Generated.Deprecated;
using BrpDtos = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class GezagDeprecatedProfile : Profile
{
    public GezagDeprecatedProfile()
    {
        CreateMap<BrpDtos.AbstractGezagsrelatie, BrpApiDtos.AbstractGezagsrelatie?>().ConvertUsing<GezagDeprecatedConverter>();

        CreateMap<BrpDtos.EenhoofdigOuderlijkGezag, BrpApiDtos.EenhoofdigOuderlijkGezag>();
        CreateMap<BrpDtos.TweehoofdigOuderlijkGezag, BrpApiDtos.TweehoofdigOuderlijkGezag>();
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

        CreateMap<BrpDtos.Derde, BrpApiDtos.Derde?>().ConvertUsing<DerdeDeprecatedConverter>();

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

public class GezagDeprecatedConverter : ITypeConverter<BrpDtos.AbstractGezagsrelatie, BrpApiDtos.AbstractGezagsrelatie?>
{
    public BrpApiDtos.AbstractGezagsrelatie? Convert(BrpDtos.AbstractGezagsrelatie source, BrpApiDtos.AbstractGezagsrelatie? destination, ResolutionContext context)
    {
        return source switch
        {
            BrpDtos.EenhoofdigOuderlijkGezag => context.Mapper.Map<BrpApiDtos.EenhoofdigOuderlijkGezag>(source),
            BrpDtos.TweehoofdigOuderlijkGezag => context.Mapper.Map<BrpApiDtos.TweehoofdigOuderlijkGezag>(source),
            BrpDtos.GezamenlijkGezag => context.Mapper.Map<BrpApiDtos.GezamenlijkGezag>(source),
            BrpDtos.Voogdij => context.Mapper.Map<BrpApiDtos.Voogdij>(source),
            BrpDtos.TijdelijkGeenGezag => context.Mapper.Map<BrpApiDtos.TijdelijkGeenGezag>(source),
            BrpDtos.GezagNietTeBepalen => context.Mapper.Map<BrpApiDtos.GezagNietTeBepalen>(source),
            _ => null
        };
    }
}

public class DerdeDeprecatedConverter : ITypeConverter<BrpDtos.Derde, BrpApiDtos.Derde?>
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