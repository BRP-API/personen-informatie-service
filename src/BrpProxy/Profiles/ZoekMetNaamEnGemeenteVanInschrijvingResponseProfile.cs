using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetNaamEnGemeenteVanInschrijvingResponseProfile : Profile
{
    public ZoekMetNaamEnGemeenteVanInschrijvingResponseProfile()
    {
        CreateMap<Gba.ZoekMetNaamEnGemeenteVanInschrijvingResponse, HC.ZoekMetNaamEnGemeenteVanInschrijvingResponse>();
        CreateMap<GbaDeprecated.ZoekMetNaamEnGemeenteVanInschrijvingResponse, HcDeprecated.ZoekMetNaamEnGemeenteVanInschrijvingResponse>();
    }
}
