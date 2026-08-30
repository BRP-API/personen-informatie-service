using Brp.Shared.DtoMappers.CommonDtos;
using Brp.Shared.DtoMappers.Mappers;
using FluentAssertions;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class AdellijkeTitelPredicaatTypeMapperTests
{
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
        input.Map().Should().BeEquivalentTo(expected);
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
        input.Map().Should().BeEquivalentTo(expected);
    }
}
