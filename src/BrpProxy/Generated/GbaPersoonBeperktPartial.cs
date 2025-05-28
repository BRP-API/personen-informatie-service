using Brp.Shared.DtoMappers.BrpDtos;

namespace HaalCentraal.BrpProxy.Generated.Gba;

public partial class GbaPersoonBeperkt : IGbaPersoonBeperkt
{
}

public interface IGbaPersoonBeperkt
{
    InOnderzoek PersoonInOnderzoek { get; }
    GbaVerblijfplaatsBeperkt Verblijfplaats { get; }
}
