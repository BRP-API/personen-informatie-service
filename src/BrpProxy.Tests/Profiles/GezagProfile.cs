using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class GezagProfile
{
    private static IMapper CreateSut() => AutomapperUnderTestFactory.CreateSut<BrpProxy.Profiles.GezagProfile>();

    [Fact]
    public void ShouldMapTweehoofdigOuderlijkGezagWithoutThrowing()
    {
        TweehoofdigOuderlijkGezag input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders = new List<GezagOuder>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        TweehoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders = new List<GezagOuder>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        CreateSut().Map<TweehoofdigOuderlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapEenhoofdigOuderlijkGezagWithoutThrowing()
    {
        EenhoofdigOuderlijkGezag input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        EenhoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        CreateSut().Map<EenhoofdigOuderlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezamenlijkGezagWithoutThrowing()
    {
        GezamenlijkGezag input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new BekendeDerde
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        GezamenlijkGezag expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new BekendeDerde
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        CreateSut().Map<GezamenlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapVoogdijWithoutThrowing()
    {
        Voogdij input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden = new List<BekendeDerde>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        Voogdij expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden = new List<BekendeDerde>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        CreateSut().Map<Voogdij>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezagNietTeBepalenWithoutThrowing()
    {
        GezagNietTeBepalen input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        GezagNietTeBepalen expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        CreateSut().Map<GezagNietTeBepalen>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapTijdelijkGeenGezagWithoutThrowing()
    {
        TijdelijkGeenGezag input = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        TijdelijkGeenGezag expected = new()
        {
            Minderjarige = new Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        CreateSut().Map<TijdelijkGeenGezag>(input).Should().BeEquivalentTo(expected);
    }
}