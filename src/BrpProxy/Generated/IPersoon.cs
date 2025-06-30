using Brp.Shared.DtoMappers.BrpApiDtos;

namespace HaalCentraal.BrpProxy.Generated;

public interface IPersoon
{
    Adressering? Adressering { get; set; }
    AbstractVerblijfplaats? Verblijfplaats { get; set; }
}