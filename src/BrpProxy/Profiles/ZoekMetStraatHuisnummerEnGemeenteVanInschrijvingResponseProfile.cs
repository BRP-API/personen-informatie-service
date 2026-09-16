using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponseMapper
{
    public static HC.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse Map(this Gba.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse src)
    {
        return new HC.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse Map(this GbaDeprecated.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse src)
    {
        return new HcDeprecated.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
