using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetPostcodeEnHuisnummerResponseMapper
{
    public static HC.ZoekMetPostcodeEnHuisnummerResponse Map(this Gba.ZoekMetPostcodeEnHuisnummerResponse src)
    {
        return new HC.ZoekMetPostcodeEnHuisnummerResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetPostcodeEnHuisnummerResponse Map(this GbaDeprecated.ZoekMetPostcodeEnHuisnummerResponse src)
    {
        return new HcDeprecated.ZoekMetPostcodeEnHuisnummerResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
