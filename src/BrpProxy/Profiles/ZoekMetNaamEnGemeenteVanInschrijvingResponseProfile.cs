using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetNaamEnGemeenteVanInschrijvingResponseMapper
{
    public static HC.ZoekMetNaamEnGemeenteVanInschrijvingResponse Map(this Gba.ZoekMetNaamEnGemeenteVanInschrijvingResponse src)
    {
        return new HC.ZoekMetNaamEnGemeenteVanInschrijvingResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetNaamEnGemeenteVanInschrijvingResponse Map(this GbaDeprecated.ZoekMetNaamEnGemeenteVanInschrijvingResponse src)
    {
        return new HcDeprecated.ZoekMetNaamEnGemeenteVanInschrijvingResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
