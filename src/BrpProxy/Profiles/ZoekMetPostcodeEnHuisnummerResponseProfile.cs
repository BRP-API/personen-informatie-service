using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetPostcodeEnHuisnummerResponseProfile : Profile
{
    public ZoekMetPostcodeEnHuisnummerResponseProfile()
    {
        CreateMap<Gba.ZoekMetPostcodeEnHuisnummerResponse, HC.ZoekMetPostcodeEnHuisnummerResponse>();
        CreateMap<GbaDeprecated.ZoekMetPostcodeEnHuisnummerResponse, HcDeprecated.ZoekMetPostcodeEnHuisnummerResponse>();
    }
}
