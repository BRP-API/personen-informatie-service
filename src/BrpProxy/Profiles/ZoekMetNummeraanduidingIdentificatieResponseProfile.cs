using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using HC = HaalCentraal.BrpProxy.Generated;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Profiles;

public static class ZoekMetNummeraanduidingIdentificatieResponseMapper
{
    public static HC.ZoekMetNummeraanduidingIdentificatieResponse Map(this Gba.ZoekMetNummeraanduidingIdentificatieResponse src)
    {
        return new HC.ZoekMetNummeraanduidingIdentificatieResponse
        {
            Personen = src.Personen.Map()
        };
    }

    public static HcDeprecated.ZoekMetNummeraanduidingIdentificatieResponse Map(this GbaDeprecated.ZoekMetNummeraanduidingIdentificatieResponse src)
    {
        return new HcDeprecated.ZoekMetNummeraanduidingIdentificatieResponse
        {
            Personen = src.Personen.Map()
        };
    }
}
