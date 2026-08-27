using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles;

public class VerblijfplaatsProfile : Profile
{
    public VerblijfplaatsProfile()
    {
        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.AbstractVerblijfplaats?>().ConvertUsing<VerblijfplaatsConverter>();

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresBuitenland>()
            .ForMember(dest => dest.Land, opt =>
            {
                opt.PreCondition(src => src.Land?.Code != "0000");
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.VerblijfadresBuitenlandInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresBinnenland>()
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
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.VerblijfadresBinnenlandInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfadresLocatie>()
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.VerblijfadresLocatieInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfplaatsOnbekend>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.MapDatumVan()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.VerblijfplaatsOnbekendInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.VerblijfplaatsBuitenland>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdresBuitenland.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.VerblijfplaatsBuitenlandInOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.Adres>()
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
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.AdresOnderzoek()))
            ;

        CreateMap<BrpDtos.GbaVerblijfplaats, BrpApiDtos.Locatie>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.IndicatieVastgesteldVerblijftNietOpAdres, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek?.AanduidingGegevensInOnderzoek != null);
                opt.MapFrom(src => src.MapVastgesteldVerblijftNietOpAdres());
            })
            .ForMember(dest => dest.InOnderzoek, opt => opt.MapFrom(src => src.InOnderzoek.LocatieInOnderzoek()))
            ;
    }
}
