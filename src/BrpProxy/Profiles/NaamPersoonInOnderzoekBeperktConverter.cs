using AutoMapper;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class NaamPersoonInOnderzoekBeperktConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NaamPersoonInOnderzoekBeperkt?>
{
    public NaamPersoonInOnderzoekBeperkt? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, NaamPersoonInOnderzoekBeperkt? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010200" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010210" => new NaamPersoonInOnderzoekBeperkt
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010220" => new NaamPersoonInOnderzoekBeperkt
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010230" => new NaamPersoonInOnderzoekBeperkt
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010240" => new NaamPersoonInOnderzoekBeperkt
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010400" or
            "010410" => new NaamPersoonInOnderzoekBeperkt
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}