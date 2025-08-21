using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class RaadpleegMetBurgerservicenummerResponseProfile : Profile
{
    public RaadpleegMetBurgerservicenummerResponseProfile()
    {
        CreateMap<Gba.RaadpleegMetBurgerservicenummerResponse, HC.RaadpleegMetBurgerservicenummerResponse>();
        CreateMap<GbaDeprecated.RaadpleegMetBurgerservicenummerResponse, HcDeprecated.RaadpleegMetBurgerservicenummerResponse>();
    }
}
