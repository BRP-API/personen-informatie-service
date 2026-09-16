using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetAdresseerbaarObjectIdentificatieResponseMapper
{
    public static HC.ZoekMetAdresseerbaarObjectIdentificatieResponse Map(this Gba.ZoekMetAdresseerbaarObjectIdentificatieResponse src)
    {
        return new HC.ZoekMetAdresseerbaarObjectIdentificatieResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetAdresseerbaarObjectIdentificatieResponse Map(this GbaDeprecated.ZoekMetAdresseerbaarObjectIdentificatieResponse src)
    {
        return new HcDeprecated.ZoekMetAdresseerbaarObjectIdentificatieResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
