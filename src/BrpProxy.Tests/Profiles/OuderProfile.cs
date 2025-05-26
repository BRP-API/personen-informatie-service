using AutoMapper;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;
using CommonDtos = Brp.Shared.DtoMappers.CommonDtos;
using BrpProxy.Profiles;
using FluentAssertions;
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
        var input = new BrpDtos.GbaOuder
        {
            Naam = new CommonDtos.NaamBasis
            {
                AdellijkeTitelPredicaat = new CommonDtos.AdellijkeTitelPredicaatType
                {
                    Soort = CommonDtos.AdellijkeTitelPredicaatSoort.Titel,
                    Code = "P",
                    Omschrijving = "prins"
                }
            }
        };
        var expected = new BrpApiDtos.Ouder
        {
            Naam = new BrpApiDtos.NaamGerelateerde
            {
                AdellijkeTitelPredicaat = new CommonDtos.AdellijkeTitelPredicaatType
                {
                    Soort = CommonDtos.AdellijkeTitelPredicaatSoort.Titel,
                    Code = "P",
                    Omschrijving = "prins"
                }
            }
        };

        CreateSut().Map<BrpApiDtos.Ouder>(input).Should().BeEquivalentTo(expected);

    }
}