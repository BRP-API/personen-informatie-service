using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using CommonDtos = Brp.Shared.DtoMappers.CommonDtos;
using BrpProxy.Mappers;
using FluentAssertions;
using Xunit;

namespace BrpProxy.Tests
{
    public class AanschrijfwijzeMapperTests
    {
        [Fact]
        public void PersoonMetPartnerZonderAanduidingNaamgebruikHeeftGeenAanschrijfwijzeNaam()
        {
            var persoon = new BrpApiDtos.NaamPersoon
            {
                Geslachtsnaam = "Jansen",
                Partners = new[]
                {
                    new BrpApiDtos.Partner
                    {
                        Naam = new BrpApiDtos.NaamGerelateerde { Geslachtsnaam = "Aedel"}
                    }
                }
            };

            var actual = persoon.Aanschrijfwijze(new CommonDtos.Waardetabel() { Code = "M" });

            actual.Should().NotBeNull();
            actual!.Naam.Should().BeNull();
        }

        [Fact]
        public void PersoonMetPartnerMetPredicaatZonderAanduidingNaamgebruikHeeftGeenAanschrijfwijzeNaam()
        {
            var persoon = new BrpApiDtos.NaamPersoon
            {
                Geslachtsnaam = "Jansen",
                AdellijkeTitelPredicaat = new CommonDtos.AdellijkeTitelPredicaatType { Code = "JH" },
                Partners = new[]
                {
                    new BrpApiDtos.Partner
                    {
                        Naam = new BrpApiDtos.NaamGerelateerde { Geslachtsnaam = "Aedel"}
                    }
                }
            };

            var actual = persoon.Aanschrijfwijze(new CommonDtos.Waardetabel() { Code = "M" });

            actual.Should().NotBeNull();
            actual!.Naam.Should().BeNull();
        }

        [Fact]
        public void PersoonMetPartnerMetAdellijkeTitelZonderAanduidingNaamgebruikHeeftGeenAanschrijfwijzeNaam()
        {
            var persoon = new BrpApiDtos.NaamPersoon
            {
                Geslachtsnaam = "Jansen",
                AdellijkeTitelPredicaat = new CommonDtos.AdellijkeTitelPredicaatType { Code = "B" },
                Partners = new[]
                {
                    new BrpApiDtos.Partner
                    {
                        Naam = new BrpApiDtos.NaamGerelateerde { Geslachtsnaam = "Aedel"}
                    }
                }
            };

            var actual = persoon.Aanschrijfwijze(new CommonDtos.Waardetabel() { Code = "M" });

            actual.Should().NotBeNull();
            actual!.Naam.Should().BeNull();
        }

        [Fact]
        public void PersoonMetPartnerMetHoffelijkheidstitelZonderAanduidingNaamgebruikHeeftGeenAanschrijfwijzeNaam()
        {
            var persoon = new BrpApiDtos.NaamPersoon
            {
                Geslachtsnaam = "Jansen",
                Partners = new[]
                {
                    new BrpApiDtos.Partner
                    {
                        Naam = new BrpApiDtos.NaamGerelateerde
                        {
                            Geslachtsnaam = "Aedel",
                            AdellijkeTitelPredicaat = new CommonDtos.AdellijkeTitelPredicaatType { Code = "B" }
                        }
                    }
                }
            };

            var actual = persoon.Aanschrijfwijze(new CommonDtos.Waardetabel { Code = "V" });

            actual.Should().NotBeNull();
            actual!.Naam.Should().BeNull();
        }
    }
}
