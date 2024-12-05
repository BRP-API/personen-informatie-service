using AutoMapper;
using HC = Brp.Shared.DtoMappers.BrpDtos;
using Gba = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Profiles;

public class WaardetabelProfile : Profile
{
    public WaardetabelProfile()
    {
        CreateMap<Gba.Waardetabel, HC.Waardetabel>();
    }
}
