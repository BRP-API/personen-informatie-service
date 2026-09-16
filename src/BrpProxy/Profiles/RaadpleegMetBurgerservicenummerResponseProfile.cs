using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class RaadpleegMetBurgerservicenummerResponseMapper
{
    public static HC.RaadpleegMetBurgerservicenummerResponse Map(this Gba.RaadpleegMetBurgerservicenummerResponse src)
    {
        return new HC.RaadpleegMetBurgerservicenummerResponse
        {
            Personen = src.Personen.Map()
        };
    }
    public static HcDeprecated.RaadpleegMetBurgerservicenummerResponse Map(this GbaDeprecated.RaadpleegMetBurgerservicenummerResponse src)
    {
        return new HcDeprecated.RaadpleegMetBurgerservicenummerResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
