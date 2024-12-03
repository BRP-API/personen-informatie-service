using AutoMapper;
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
        HaalCentraal.BrpProxy.Generated.Gba.TweehoofdigOuderlijkGezag input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders = new List<HaalCentraal.BrpProxy.Generated.Gba.GezagOuder>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        HaalCentraal.BrpProxy.Generated.TweehoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouders = new List<HaalCentraal.BrpProxy.Generated.GezagOuder>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.TweehoofdigOuderlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapEenhoofdigOuderlijkGezagWithoutThrowing()
    {
        HaalCentraal.BrpProxy.Generated.Gba.EenhoofdigOuderlijkGezag input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new HaalCentraal.BrpProxy.Generated.Gba.GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        HaalCentraal.BrpProxy.Generated.EenhoofdigOuderlijkGezag expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Ouder = new HaalCentraal.BrpProxy.Generated.GezagOuder
            {
                Burgerservicenummer = "000000013"
            }
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.EenhoofdigOuderlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezamenlijkGezagWithoutThrowing()
    {
        HaalCentraal.BrpProxy.Generated.Gba.GezamenlijkGezag input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new HaalCentraal.BrpProxy.Generated.Gba.Meerderjarige
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new HaalCentraal.BrpProxy.Generated.Gba.GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        HaalCentraal.BrpProxy.Generated.GezamenlijkGezag expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derde = new HaalCentraal.BrpProxy.Generated.Meerderjarige
            {
                Burgerservicenummer = "000000013"
            },
            Ouder = new HaalCentraal.BrpProxy.Generated.GezagOuder
            {
                Burgerservicenummer = "000000014"
            }
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.GezamenlijkGezag>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapVoogdijWithoutThrowing()
    {
        HaalCentraal.BrpProxy.Generated.Gba.Voogdij input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden = new List<HaalCentraal.BrpProxy.Generated.Gba.Meerderjarige>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        HaalCentraal.BrpProxy.Generated.Voogdij expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Derden = new List<HaalCentraal.BrpProxy.Generated.Meerderjarige>
            {
                new() { Burgerservicenummer = "000000013" },
                new() { Burgerservicenummer = "000000014" },
            }
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.Voogdij>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapGezagNietTeBepalenWithoutThrowing()
    {
        HaalCentraal.BrpProxy.Generated.Gba.GezagNietTeBepalen input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        HaalCentraal.BrpProxy.Generated.GezagNietTeBepalen expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            },
            Toelichting = "Toelichting",
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.GezagNietTeBepalen>(input).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldMapTijdelijkGeenGezagWithoutThrowing()
    {
        HaalCentraal.BrpProxy.Generated.Gba.TijdelijkGeenGezag input = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Gba.Minderjarige
            {
                Burgerservicenummer = "000000012"
            }
        };

        HaalCentraal.BrpProxy.Generated.TijdelijkGeenGezag expected = new()
        {
            Minderjarige = new HaalCentraal.BrpProxy.Generated.Minderjarige
            {
                Burgerservicenummer = "000000012"
            }
        };

        CreateSut().Map<HaalCentraal.BrpProxy.Generated.Gba.TijdelijkGeenGezag>(input).Should().BeEquivalentTo(expected);
    }
}