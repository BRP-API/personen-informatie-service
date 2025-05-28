using AutoMapper;
using HC = HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using HcDeprecated = HaalCentraal.BrpProxy.Generated.Deprecated;
using GbaDeprecated = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;

namespace BrpProxy.Profiles;

public class ZoekMetGeslachtsnaamEnGeboortedatumResponseProfile : Profile
{
    public ZoekMetGeslachtsnaamEnGeboortedatumResponseProfile()
    {
        CreateMap<Gba.ZoekMetGeslachtsnaamEnGeboortedatumResponse, HC.ZoekMetGeslachtsnaamEnGeboortedatumResponse>();
        CreateMap<GbaDeprecated.ZoekMetGeslachtsnaamEnGeboortedatumResponse, HcDeprecated.ZoekMetGeslachtsnaamEnGeboortedatumResponse>();
    }
}
