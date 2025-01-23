using AutoMapper;
using HC = Brp.Shared.DtoMappers.CommonDtos;
using Gba = Brp.Shared.DtoMappers.CommonDtos;

namespace BrpProxy.Profiles;

public class WaardetabelProfile : Profile
{
    public WaardetabelProfile()
    {
        CreateMap<Gba.Waardetabel, HC.Waardetabel>();
    }
}
