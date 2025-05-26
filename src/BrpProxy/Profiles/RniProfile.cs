using AutoMapper;
namespace BrpProxy.Profiles;

public class RniProfile : Profile
{
	public RniProfile()
	{
		CreateMap<Brp.Shared.DtoMappers.CommonDtos.RniDeelnemer, Brp.Shared.DtoMappers.CommonDtos.RniDeelnemer>();
	}
}
