using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.BrpDtos;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;

namespace BrpProxy.Profiles;

public class VerblijfplaatsProfile : Profile
{
    public VerblijfplaatsProfile()
    {
        CreateMap<GbaVerblijfplaats, AbstractVerblijfplaats?>().ConvertUsing<VerblijfplaatsConverter>();

        CreateMap<GbaVerblijfplaats, VerblijfadresBuitenland>()
            .ForMember(dest => dest.Land, opt =>
            {
                opt.PreCondition(src => src.Land?.Code != "0000");
            })
            ;

        CreateMap<GbaVerblijfplaats, VerblijfadresBinnenland>()
            .ForMember(dest => dest.OfficieleStraatnaam, opt =>
            {
                opt.MapFrom(src => src.NaamOpenbareRuimte);
            })
            .ForMember(dest => dest.KorteStraatnaam, opt => 
            {
                opt.PreCondition(src => src.Straat != ".");
                opt.MapFrom(src => src.Straat);
            })
            .ForMember(dest => dest.Woonplaats, opt =>
            {
                opt.PreCondition(src => src.Woonplaats != ".");
                opt.MapFrom(src => src.Woonplaats);
            })
            ;

        CreateMap<GbaVerblijfplaats, VerblijfadresLocatie>();

        CreateMap<GbaVerblijfplaats, VerblijfplaatsOnbekend>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.MapDatumVan()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            ;

        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, AdresInOnderzoek?>().ConvertUsing<AdresInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfadresBinnenlandInOnderzoek?>().ConvertUsing<VerblijfadresBinnenlandInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfplaatsBuitenlandInOnderzoek?>().ConvertUsing<VerblijfplaatsBuitenlandInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfadresBuitenlandInOnderzoek?>().ConvertUsing<VerblijfadresBuitenlandInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, LocatieInOnderzoek?>().ConvertUsing<LocatieInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfadresLocatieInOnderzoek?>().ConvertUsing<VerblijfadresLocatieInOnderzoekConverter>();
        CreateMap<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, VerblijfplaatsOnbekendInOnderzoek?>().ConvertUsing<VerblijfplaatsOnbekendInOnderzoekConverter>();

        CreateMap<GbaVerblijfplaats, VerblijfplaatsBuitenland>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdresBuitenland.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            ;

        CreateMap<GbaVerblijfplaats, Adres>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.AdresseerbaarObjectIdentificatie, opt =>
            {
                opt.PreCondition(src => src.AdresseerbaarObjectIdentificatie != "0000000000000000");
                opt.MapFrom(src => src.AdresseerbaarObjectIdentificatie);
            })
            .ForMember(dest => dest.NummeraanduidingIdentificatie, opt =>
            {
                opt.PreCondition(src => src.NummeraanduidingIdentificatie != "0000000000000000");
                opt.MapFrom(src => src.NummeraanduidingIdentificatie);
            })
            .ForMember(dest => dest.IndicatieVastgesteldVerblijftNietOpAdres, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek?.AanduidingGegevensInOnderzoek != null);
                opt.MapFrom(src => src.MapVastgesteldVerblijftNietOpAdres());
            })
            ;

        CreateMap<GbaVerblijfplaats, Locatie>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.IndicatieVastgesteldVerblijftNietOpAdres, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek?.AanduidingGegevensInOnderzoek != null);
                opt.MapFrom(src => src.MapVastgesteldVerblijftNietOpAdres());
            })
            ;
    }
}
