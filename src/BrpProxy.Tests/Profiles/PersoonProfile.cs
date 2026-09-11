using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.BrpDtos;
using Brp.Shared.DtoMappers.Mappers;
using FluentAssertions;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using System.Collections.ObjectModel;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class PersoonProfile
{
    private static IMapper CreateSut() => AutomapperUnderTestFactory.CreateSut<BrpProxy.Profiles.PersoonProfile>();

    [Fact]
    public void ShouldMapPersoonBeperkt()
    {
        GbaPersoonBeperkt input = new()
        {
            Burgerservicenummer = "123456789"
        };
        PersoonBeperkt expected = new()
        {
            Burgerservicenummer = "123456789",
            Rni = [],
        };

        var actual = CreateSut().Map<PersoonBeperkt>(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapNaamForPersoonBeperkt()
    {
        GbaPersoonBeperkt input = new()
        {
            Naam = new Brp.Shared.DtoMappers.CommonDtos.NaamBasis
            {
                Voornamen = "Pieter",
                Voorvoegsel = "van den",
                Geslachtsnaam = "Aedel"
            }
        };
        PersoonBeperkt expected = new()
        {
            Naam = new()
            {
                Voornamen = "Pieter",
                Voorvoegsel = "van den",
                Geslachtsnaam = "Aedel",
                Voorletters = "P.",
                VolledigeNaam = "Pieter van den Aedel"
            },
            Rni = []
        };
        var actual = CreateSut().Map<PersoonBeperkt>(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGeboorteForPersoonBeperkt()
    {
        GbaPersoonBeperkt input = new()
        {
            Geboorte = new Brp.Shared.DtoMappers.BrpDtos.GeboorteBasis
            {
                Datum = "20240102"
            }
        };
        PersoonBeperkt expected = new()
        {
            Geboorte = new()
            {
                Datum = "20240102".Map()
            },
            Leeftijd = 2,
            Rni = []
        };
        var actual = CreateSut().Map<PersoonBeperkt>(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGeboorteForPersoon()
    {
        GbaPersoon input = new()
        {
            Geboorte = new Brp.Shared.DtoMappers.BrpDtos.GbaGeboorte
            {
                Datum = "20240102"
            }
        };
        Persoon expected = new()
        {
            GeheimhoudingPersoonsgegevens = false,
            Geboorte = new()
            {
                Datum = "20240102".Map()
            },
            Gezag = [],
            Leeftijd = 2,
            Nationaliteiten = [],
            Kinderen = [],
            Ouders = [],
            Partners= [],
            Rni = []
        };
        var actual = CreateSut().Map<Persoon>(input);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapVerificatieForPersoonBeperkt()
    {
        GbaPersoonBeperkt input = new()
        {
            Verificatie = new Brp.Shared.DtoMappers.BrpDtos.GbaVerificatie
            {
                Datum = "20240102",
                Omschrijving = "geverifieerd"
            }
        };

        Verificatie expected = new()
        {
            Datum = "20240102".Map(),
            Omschrijving = "geverifieerd"
        };

        CreateSut().Map<PersoonBeperkt>(input).Verificatie.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapVerificatieForPersoon()
    {
        GbaPersoon input = new()
        {
            Verificatie = new Brp.Shared.DtoMappers.BrpDtos.GbaVerificatie
            {
                Datum = "20240102",
                Omschrijving = "geverifieerd"
            }
        };

        Verificatie expected = new()
        {
            Datum = "20240102".Map(),
            Omschrijving = "geverifieerd"
        };

        CreateSut().Map<Persoon>(input).Verificatie.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapRniForPersoonBeperkt()
    {
        GbaPersoonBeperkt input = new()
        {
            Rni =
            [
                new Brp.Shared.DtoMappers.CommonDtos.RniDeelnemer
                {
                    Categorie = "cat-01",
                    OmschrijvingVerdrag = "verdrag",
                    Deelnemer = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
                    {
                        Code = "0001",
                        Omschrijving = "deelnemer"
                    }
                }
            ]
        };

        CreateSut().Map<PersoonBeperkt>(input).Rni.Should().BeEquivalentTo(input.Rni);
    }

    [Fact]
    public void ShouldMapRniForPersoon()
    {
        GbaPersoon input = new()
        {
            Rni =
            [
                new Brp.Shared.DtoMappers.CommonDtos.RniDeelnemer
                {
                    Categorie = "cat-01",
                    OmschrijvingVerdrag = "verdrag",
                    Deelnemer = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
                    {
                        Code = "0001",
                        Omschrijving = "deelnemer"
                    }
                }
            ]
        };

        CreateSut().Map<Persoon>(input).Rni.Should().BeEquivalentTo(input.Rni);
    }

    [Fact]
    public void ShouldMapVerblijfstitelForPersoon()
    {
        GbaPersoon input = new()
        {
            Verblijfstitel = new Brp.Shared.DtoMappers.BrpDtos.GbaVerblijfstitel
            {
                Aanduiding = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
                {
                    Code = "01",
                    Omschrijving = "verblijfstitel"
                },
                DatumIngang = "20240102",
                DatumEinde = "20240103",
            }
        };
        Brp.Shared.DtoMappers.BrpApiDtos.Verblijfstitel expected = new()
        {
            Aanduiding = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
            {
                Code = "01",
                Omschrijving = "verblijfstitel"
            },
            DatumIngang = "20240102".Map(),
            DatumEinde = "20240103".Map()
        };
        CreateSut().Map<Persoon>(input).Verblijfstitel.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapUitsluitingKiesrechtForPersoon()
    {
        GbaPersoon input = new()
        {
            UitsluitingKiesrecht = new Brp.Shared.DtoMappers.BrpDtos.GbaUitsluitingKiesrecht
            {
                UitgeslotenVanKiesrecht = true,
                Einddatum = "20240103"
            }
        };
        Brp.Shared.DtoMappers.BrpApiDtos.UitsluitingKiesrecht expected = new()
        {
            UitgeslotenVanKiesrecht = true,
            Einddatum = "20240103".Map()
        };
        CreateSut().Map<Persoon>(input).UitsluitingKiesrecht.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapEuropeesKiesrechtForPersoon()
    {
        GbaPersoon input = new()
        {
            EuropeesKiesrecht = new Brp.Shared.DtoMappers.BrpDtos.GbaEuropeesKiesrecht
            {
                Aanduiding = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
                {
                    Code = "01",
                    Omschrijving = "europees kiesrecht"
                },
                EinddatumUitsluiting = "20240103"
            }
        };
        Brp.Shared.DtoMappers.BrpApiDtos.EuropeesKiesrecht expected = new()
        {
            Aanduiding = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
            {
                Code = "01",
                Omschrijving = "europees kiesrecht"
            },
            EinddatumUitsluiting = "20240103".Map()
        };
        CreateSut().Map<Persoon>(input).EuropeesKiesrecht.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapImmigratieForPersoon()
    {
        GbaPersoon input = new()
        {
            Immigratie = new Brp.Shared.DtoMappers.BrpDtos.GbaImmigratie
            {
                DatumVestigingInNederland = "20240102",
                LandVanwaarIngeschreven = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
                {
                    Code = "6014",
                    Omschrijving = "Verenigde Staten van Amerika"
                }
            }
        };
        Brp.Shared.DtoMappers.BrpApiDtos.Immigratie expected = new()
        {
            DatumVestigingInNederland = "20240102".Map(),
            LandVanwaarIngeschreven = new Brp.Shared.DtoMappers.CommonDtos.Waardetabel
            {
                Code = "6014",
                Omschrijving = "Verenigde Staten van Amerika"
            },
            IndicatieVestigingVanuitBuitenland = true
        };
        CreateSut().Map<Persoon>(input).Immigratie.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapAanhef()
    {
        GbaPersoon input = new()
        {
            Geslacht = new Brp.Shared.DtoMappers.CommonDtos.Geslachtsaanduiding
            {
                Code = "M"
            },
            Naam = new()
            {
                Voornamen = "Pieter",
                AdellijkeTitelPredicaat = new()
                {
                    Code = "G",
                    Soort = Brp.Shared.DtoMappers.CommonDtos.AdellijkeTitelPredicaatSoort.Titel
                },
                Voorvoegsel = "van den",
                Geslachtsnaam = "Aedel",
                AanduidingNaamgebruik = new()
                {
                    Code = "P"
                }
            },
            Partners = new Collection<Brp.Shared.DtoMappers.BrpDtos.GbaPartner>
            {
                new GbaPartner
                {
                    Naam = new()
                    {
                        Voorvoegsel = "de",
                        Geslachtsnaam = "Boer"
                    }
                }
            }
        };
        CreateSut().Map<Persoon>(input).Adressering.Aanhef.Should().Be("Geachte heer De Boer");
    }
}
