﻿using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Profiles;

public class NationaliteitProfile : Profile
{
    public NationaliteitProfile()
    {
        CreateMap<GbaNationaliteit, AbstractNationaliteit?>().ConvertUsing<NationaliteitConverter>();

        CreateMap<GbaNationaliteit, NationaliteitBekend>()
            .ForMember(dest => dest.Nationaliteit, opt => opt.MapFrom(src => src.Nationaliteit))
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NationaliteitBekendInOnderzoek?>().ConvertUsing<NationaliteitInOnderzoekConverter>();

        CreateMap<GbaNationaliteit, BehandeldAlsNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<GbaNationaliteit, VastgesteldNietNederlander>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, BijzonderNederlanderschapInOnderzoek?>().ConvertUsing<BijzonderNederlanderschapInOnderzoekConverter>();

        CreateMap<GbaNationaliteit, Staatloos>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, StaatloosInOnderzoek?>().ConvertUsing<StaatloosInOnderzoekConverter>();

        CreateMap<GbaNationaliteit, NationaliteitOnbekend>()
            .ForMember(dest => dest.DatumIngangGeldigheid, opt => opt.MapFrom(src => src.DatumIngangGeldigheid.Map()))
            .ForMember(dest => dest.RedenOpname, opt => opt.PreCondition(src => src.RedenOpname?.Code != "000"))
            ;

        CreateMap<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NationaliteitOnbekendInOnderzoek?>().ConvertUsing<NationaliteitOnbekendInOnderzoekConverter>();
    }
}
