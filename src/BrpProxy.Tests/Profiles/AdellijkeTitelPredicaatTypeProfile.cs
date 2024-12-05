using AutoMapper;
using Brp.Shared.DtoMappers.BrpDtos;
using FluentAssertions;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class AdellijkeTitelPredicaatTypeProfile
{
    private static IMapper CreateSut() => AutomapperUnderTestFactory.CreateSut<BrpProxy.Profiles.AdellijkeTitelPredicaatTypeProfile>();

    [Fact]
    public void Titel()
    {
        AdellijkeTitelPredicaatType input = new()
        {
            Soort = AdellijkeTitelPredicaatSoort.Titel,
            Code = "P",
            Omschrijving = "prins"
        };
        AdellijkeTitelPredicaatType expected = new()
        {
            Soort = AdellijkeTitelPredicaatSoort.Titel,
            Code = "P",
            Omschrijving = "prins"
        };
        CreateSut().Map<AdellijkeTitelPredicaatType>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Predicaat()
    {
        AdellijkeTitelPredicaatType input = new()
        {
            Soort = AdellijkeTitelPredicaatSoort.Predicaat,
            Code = "JH",
            Omschrijving = "jonkheer"
        };
        AdellijkeTitelPredicaatType expected = new()
        {
            Soort = AdellijkeTitelPredicaatSoort.Predicaat,
            Code = "JH",
            Omschrijving = "jonkheer"
        };
        CreateSut().Map<AdellijkeTitelPredicaatType>(input).Should().BeEquivalentTo(expected);
    }
}
