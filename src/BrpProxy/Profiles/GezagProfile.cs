using AutoMapper;
using Hc = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;

namespace BrpProxy.Profiles;

public class GezagProfile : Profile
{
    public GezagProfile()
    {
        CreateMap<Gba.AbstractGezagsrelatie, Hc.AbstractGezagsrelatie?>().ConvertUsing<GezagConverter>();

        CreateMap<Gba.EenhoofdigOuderlijkGezag, Hc.EenhoofdigOuderlijkGezag>();
        CreateMap<Gba.TweehoofdigOuderlijkGezag, Hc.TweehoofdigOuderlijkGezag>();
        CreateMap<Gba.GezamenlijkGezag, Hc.GezamenlijkGezag>();
        CreateMap<Gba.Voogdij, Hc.Voogdij>();
        CreateMap<Gba.TijdelijkGeenGezag, Hc.TijdelijkGeenGezag>();
        CreateMap<Gba.GezagNietTeBepalen, Hc.GezagNietTeBepalen>();

        CreateMap<Gba.GezagOuder, Hc.GezagOuder>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            });
        CreateMap<Gba.Minderjarige, Hc.Minderjarige>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            })
            .ForMember(dest => dest.Leeftijd, opt =>
            {
                opt.MapFrom(src => src.Geboorte.Datum.Map().Leeftijd());
            });
        CreateMap<Gba.Meerderjarige, Hc.Meerderjarige>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            });
    }
}

public class GezagConverter : ITypeConverter<Gba.AbstractGezagsrelatie, Hc.AbstractGezagsrelatie?>
{
    public Hc.AbstractGezagsrelatie? Convert(Gba.AbstractGezagsrelatie source, Hc.AbstractGezagsrelatie? destination, ResolutionContext context)
    {
        return source switch
        {
            Gba.EenhoofdigOuderlijkGezag => context.Mapper.Map<Hc.EenhoofdigOuderlijkGezag>(source),
            Gba.TweehoofdigOuderlijkGezag => context.Mapper.Map<Hc.TweehoofdigOuderlijkGezag>(source),
            Gba.GezamenlijkGezag => context.Mapper.Map<Hc.GezamenlijkGezag>(source),
            Gba.Voogdij => context.Mapper.Map<Hc.Voogdij>(source),
            Gba.TijdelijkGeenGezag => context.Mapper.Map<Hc.TijdelijkGeenGezag>(source),
            Gba.GezagNietTeBepalen => context.Mapper.Map<Hc.GezagNietTeBepalen>(source),
            _ => null
        };
    }
}
