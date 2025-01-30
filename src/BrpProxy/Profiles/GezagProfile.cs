using AutoMapper;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class GezagProfile : Profile
{
    public GezagProfile()
    {
        CreateMap<BrpDtos.AbstractGezagsrelatie, BrpApiDtos.AbstractGezagsrelatie?>().ConvertUsing<GezagConverter>();

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
        CreateMap<BrpDtos.Meerderjarige, BrpApiDtos.Meerderjarige>()
            .AfterMap((src, dest) =>
            {
                if (src.Naam is null) return;
                dest.Naam.VolledigeNaam = src.Naam.VolledigeNaam(src.Geslacht);
            });
    }
}

public class GezagConverter : ITypeConverter<BrpDtos.AbstractGezagsrelatie, BrpApiDtos.AbstractGezagsrelatie?>
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