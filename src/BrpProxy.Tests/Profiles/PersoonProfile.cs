using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;
using FluentAssertions;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class PersoonProfile
{
    private static IMapper CreateSut() => AutomapperUnderTestFactory.CreateSut<BrpProxy.Profiles.PersoonProfile>();

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
}
