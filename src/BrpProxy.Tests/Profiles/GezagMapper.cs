using BrpProxy.Mappers;
using FluentAssertions;
using Xunit;
using BrpApiDtos = HaalCentraal.BrpProxy.Generated;
using BrpDtos = HaalCentraal.BrpProxy.Generated.Gba;

namespace BrpProxy.Tests.Profiles;

public class GezagMapper
{
    [Fact]
    public void ShouldMapGezamenlijkOuderlijkGezagWithoutThrowing()
    {
        BrpDtos.Gezagsrelatie input = new BrpDtos.GezamenlijkOuderlijkGezag()
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

        BrpApiDtos.GezamenlijkOuderlijkGezag expected = new()
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
        BrpDtos.Gezagsrelatie input = new BrpDtos.EenhoofdigOuderlijkGezag()
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
        BrpDtos.Gezagsrelatie input = new BrpDtos.GezamenlijkGezag()
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
        BrpDtos.Gezagsrelatie input = new BrpDtos.Voogdij()
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
        BrpDtos.Gezagsrelatie input = new BrpDtos.GezagNietTeBepalen()
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
        BrpDtos.Gezagsrelatie input = new BrpDtos.TijdelijkGeenGezag()
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