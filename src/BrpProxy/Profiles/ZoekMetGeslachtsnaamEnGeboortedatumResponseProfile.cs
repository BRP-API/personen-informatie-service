using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetGeslachtsnaamEnGeboortedatumResponseMapper
{
    public static HC.ZoekMetGeslachtsnaamEnGeboortedatumResponse Map(this Gba.ZoekMetGeslachtsnaamEnGeboortedatumResponse src)
    {
        return new HC.ZoekMetGeslachtsnaamEnGeboortedatumResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetGeslachtsnaamEnGeboortedatumResponse Map(this GbaDeprecated.ZoekMetGeslachtsnaamEnGeboortedatumResponse src)
    {
        return new HcDeprecated.ZoekMetGeslachtsnaamEnGeboortedatumResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
