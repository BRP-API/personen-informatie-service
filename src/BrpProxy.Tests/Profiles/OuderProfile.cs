using AutoMapper;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;
using CommonDtos = Brp.Shared.DtoMappers.CommonDtos;
using FluentAssertions;
using Xunit;
using Brp.Shared.DtoMappers.Profiles;

namespace BrpProxy.Tests.Profiles;

public class OuderProfile
{
    private static IMapper CreateSut()
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.AddProfile<Brp.Shared.DtoMappers.Profiles.OuderProfile>();
            cfg.AddProfile<NaamProfile>();
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