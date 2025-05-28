using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetAdresseerbaarObjectIdentificatieResponseProfile : Profile
{
    public ZoekMetAdresseerbaarObjectIdentificatieResponseProfile()
    {
        CreateMap<Gba.ZoekMetAdresseerbaarObjectIdentificatieResponse, HC.ZoekMetAdresseerbaarObjectIdentificatieResponse>();
        CreateMap<GbaDeprecated.ZoekMetAdresseerbaarObjectIdentificatieResponse, HcDeprecated.ZoekMetAdresseerbaarObjectIdentificatieResponse>();
    }
}
