using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;
using BrpProxy.Mappers;
using BrpProxy.Profiles;
using FluentAssertions;
using HaalCentraal.BrpProxy.Generated.Gba;
using Xunit;

namespace BrpProxy.Tests.Mappers;

public class PersoonMapperTests
{
    [Fact]
    public void MapPartnerInOnderzoekToAdresseringInOnderzoek()
    {
        GbaPersoon input = new()
        {
            Partners = [
                new Brp.Shared.DtoMappers.BrpDtos.GbaPartner
                {
                    Naam = new Brp.Shared.DtoMappers.CommonDtos.NaamBasis
                    {
                        Geslachtsnaam = "."
                    },
                    InOnderzoek = new Brp.Shared.DtoMappers.BrpDtos.InOnderzoek
                    {
                        AanduidingGegevensInOnderzoek = "050000",
                        DatumIngangOnderzoek = "2023-01-01"
                    }
                }
                ]
        };
        AdresseringInOnderzoek expected = new()
        {
            Aanschrijfwijze = true,
            Aanhef = true,
            GebruikInLopendeTekst = true,
            DatumIngangOnderzoekPartner = "2023-01-01".Map(),
        };

        input.MapPersoon().Adressering.InOnderzoek.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void MapVerblijfplaatsInOnderzoekToImmigratieInOnderzoek()
    {
        GbaPersoon input = new()
        {
            Verblijfplaats = new Brp.Shared.DtoMappers.BrpDtos.GbaVerblijfplaats
            {
                InOnderzoek = new Brp.Shared.DtoMappers.BrpDtos.InOnderzoek
                {
                    AanduidingGegevensInOnderzoek = "080000",
                    DatumIngangOnderzoek = "2023-01-01"
                }
            }
        };

        ImmigratieInOnderzoek expected = new()
        {
            DatumVestigingInNederland = true,
            LandVanwaarIngeschreven = true,
            VanuitVerblijfplaatsOnbekend = true,
            IndicatieVestigingVanuitBuitenland = true,
            DatumIngangOnderzoek = "2023-01-01".Map(),
        };

        input.MapPersoon().Immigratie.InOnderzoek.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void MapPersoonInOnderzoekToNaamInOnderzoek()
    {
        GbaPersoon input = new()
        {
            PersoonInOnderzoek = new Brp.Shared.DtoMappers.BrpDtos.InOnderzoek
            {
                AanduidingGegevensInOnderzoek = "010000",
                DatumIngangOnderzoek = "2023-01-01"
            }
        };
        NaamPersoonInOnderzoek expected = new()
        {
            Voornamen = true,
            AdellijkeTitelPredicaat = true,
            Voorvoegsel = true,
            Geslachtsnaam = true,
            AanduidingNaamgebruik = true,
            Voorletters = true,
            VolledigeNaam = true,
            DatumIngangOnderzoek = "2023-01-01".Map(),
        };
        input.MapPersoon().Naam.InOnderzoek.Should().BeEquivalentTo(expected);
    }
}
