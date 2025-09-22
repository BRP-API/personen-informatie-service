using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetNummeraanduidingIdentificatieResponseProfile : Profile
{
    public ZoekMetNummeraanduidingIdentificatieResponseProfile()
    {
        CreateMap<Gba.ZoekMetNummeraanduidingIdentificatieResponse, HC.ZoekMetNummeraanduidingIdentificatieResponse>();
        CreateMap<GbaDeprecated.ZoekMetNummeraanduidingIdentificatieResponse, HcDeprecated.ZoekMetNummeraanduidingIdentificatieResponse>();
    }
}
