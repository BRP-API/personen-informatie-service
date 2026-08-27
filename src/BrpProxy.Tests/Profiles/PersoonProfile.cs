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
}
