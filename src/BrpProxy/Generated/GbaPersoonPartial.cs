using Brp.Shared.DtoMappers.BrpDtos;

namespace HaalCentraal.BrpProxy.Generated.Gba;

public partial class GbaPersoon : IGbaPersoon
{
}

public interface IGbaPersoon
{
    int? GeheimhoudingPersoonsgegevens { get; }
    InOnderzoek PersoonInOnderzoek { get; }
    InOnderzoek GezagInOnderzoek { get; }
    GbaVerblijfplaats Verblijfplaats { get; }
    System.Collections.Generic.ICollection<GbaPartner> Partners { get; }
    GbaNaamPersoon Naam { get; set; }
    
    GbaGeboorte Geboorte { get; set; }
    
    GbaImmigratie Immigratie { get; set; }
    
    Brp.Shared.DtoMappers.CommonDtos.Geslachtsaanduiding Geslacht { get; }
    Brp.Shared.DtoMappers.CommonDtos.Waardetabel GemeenteVanInschrijving { get; }
}