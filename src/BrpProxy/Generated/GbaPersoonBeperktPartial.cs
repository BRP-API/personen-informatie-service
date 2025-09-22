using Brp.Shared.DtoMappers.BrpDtos;

namespace HaalCentraal.BrpProxy.Generated.Gba;

public partial class GbaPersoonBeperkt : IGbaPersoonBeperkt
{
}

public interface IGbaPersoonBeperkt
{
    InOnderzoek PersoonInOnderzoek { get; }
    GeboorteBasis Geboorte { get; set; }
    GbaOpschortingBijhouding OpschortingBijhouding { get; }
    GbaVerblijfplaatsBeperkt Verblijfplaats { get; }
    
    Brp.Shared.DtoMappers.CommonDtos.Waardetabel GemeenteVanInschrijving { get; }
    Brp.Shared.DtoMappers.CommonDtos.NaamBasis Naam { get; set; }
    Brp.Shared.DtoMappers.CommonDtos.Geslachtsaanduiding Geslacht { get; }
}
