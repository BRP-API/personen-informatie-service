﻿using AutoMapper;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using HC = HaalCentraal.BrpProxy.Generated;
using GBA = HaalCentraal.BrpProxy.Generated.Gba;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class OpschortingBijhoudingProfile : Profile
{
    public OpschortingBijhoudingProfile()
    {
        CreateMap<GBA.OpschortingBijhoudingBasis, HC.OpschortingBijhoudingBasis>();

        CreateMap<GbaOpschortingBijhouding, OpschortingBijhouding>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()));
    }
}
