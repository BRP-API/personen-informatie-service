using Brp.Shared.DtoMappers.BrpApiDtos;

namespace HaalCentraal.BrpProxy.Generated;

public interface IPersoonBeperkt
{
    Brp.Shared.DtoMappers.BrpApiDtos.AdresseringBeperkt Adressering { get; set; }
    int? Leeftijd { get; set; }
    PersoonInOnderzoekBeperkt InOnderzoek { get; set; }
    
    NaamPersoonBeperkt Naam { get; set; }
    
    GeboorteBeperkt Geboorte { get; set; }
}

public partial class PersoonBeperkt : IPersoonBeperkt
{
    public bool ShouldSerializeAdressering() => Adressering != null && Adressering.ShouldSerialize();
    public bool ShouldSerializeInOnderzoek() => InOnderzoek != null && InOnderzoek.ShouldSerialize();
    public bool ShouldSerializeRni() => Rni != null && Rni.Count > 0;
}
