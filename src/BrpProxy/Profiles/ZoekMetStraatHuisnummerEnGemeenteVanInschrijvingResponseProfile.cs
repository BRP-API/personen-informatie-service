using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponseProfile : Profile
{
    public ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponseProfile()
    {
        CreateMap<Gba.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse, HC.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse>();
        CreateMap<GbaDeprecated.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse, HcDeprecated.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse>();
    }
}
