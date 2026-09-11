using BrpApiDtos = HaalCentraal.BrpProxy.Generated.Deprecated;
using BrpDtos = HaalCentraal.BrpProxy.Generated.Gba.Deprecated;
using BrpProxy.Mappers;
using FluentAssertions;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class GezagDeprecatedMapper
{
    [Fact]
    public void ShouldMapTweehoofdigOuderlijkGezagWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.TweehoofdigOuderlijkGezag()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders =
            [
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            ]
        };

        BrpApiDtos.TweehoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders =
            [
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            ]
        };

        input.Map().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapEenhoofdigOuderlijkGezagWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.EenhoofdigOuderlijkGezag()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new BrpDtos.GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        BrpApiDtos.EenhoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new BrpApiDtos.GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        input.Map().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezamenlijkGezagWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.GezamenlijkGezag()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new BrpDtos.BekendeDerde
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new BrpDtos.GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        BrpApiDtos.GezamenlijkGezag expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new BrpApiDtos.BekendeDerde
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new BrpApiDtos.GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        input.Map().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapVoogdijWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.Voogdij()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden =
            [
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            ]
        };

        BrpApiDtos.Voogdij expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden =
            [
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            ]
        };

        input.Map().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezagNietTeBepalenWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.GezagNietTeBepalen()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        BrpApiDtos.GezagNietTeBepalen expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        input.Map().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapTijdelijkGeenGezagWithoutThrowing()
    {
        BrpDtos.AbstractGezagsrelatie input = new BrpDtos.TijdelijkGeenGezag()
        {
            Minderjarige = new BrpDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        BrpApiDtos.TijdelijkGeenGezag expected = new()
        {
            Minderjarige = new BrpApiDtos.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        input.Map().Should().BeEquivalentTo(expected);
    }
}