using AutoMapper;
using Brp.Shared.DtoMappers.BrpDtos;
using BrpProxy.Profiles;
using FluentAssertions;
using HaalCentraal.BrpProxy.Generated;
using HaalCentraal.BrpProxy.Generated.Gba;
using Xunit;

namespace BrpProxy.Tests.Profiles;

public class OuderProfile
{
    private static IMapper CreateSut()
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.AddProfile<BrpProxy.Profiles.OuderProfile>();
            cfg.AddProfile<BrpProxy.Profiles.NaamProfile>();
        });
        return config.CreateMapper();
    }

    [Fact]
    public void OuderMetTitel()
    {
        var input = new GbaOuder
        {
            Naam = new HaalCentraal.BrpProxy.Generated.Gba.NaamBasis
            {
                AdellijkeTitelPredicaat = new AdellijkeTitelPredicaatType
                {
                    Soort = AdellijkeTitelPredicaatSoort.Titel,
                    Code = "P",
                    Omschrijving = "prins"
                }
            }
        };
        var expected = new Ouder
        {
            Naam = new NaamGerelateerde
            {
                AdellijkeTitelPredicaat = new AdellijkeTitelPredicaatType
                {
                    Soort = AdellijkeTitelPredicaatSoort.Titel,
                    Code = "P",
                    Omschrijving = "prins"
                }
            }
        };

        CreateSut().Map<Ouder>(input).Should().BeEquivalentTo(expected);

    }
}