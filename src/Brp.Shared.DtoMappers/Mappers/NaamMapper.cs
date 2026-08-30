using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Interfaces;
using System.Collections.ObjectModel;

namespace Brp.Shared.DtoMappers.Mappers;

public static class NaamMapper
{
    public static string Achternaam(this INaamBasis? naam)
    {
        return naam != null &&
               !string.IsNullOrWhiteSpace(naam.Geslachtsnaam) &&
               naam.Geslachtsnaam != "."
            ? $"{naam.Voorvoegsel} {naam.Geslachtsnaam}".RemoveRedundantSpaces()
            : string.Empty;
    }

    public static NaamPersoonBeperkt? Map(this CommonDtos.NaamBasis? naam, CommonDtos.Waardetabel geslacht)
    {
        return naam == null
            ? null
            : new NaamPersoonBeperkt
            {
                AdellijkeTitelPredicaat = naam.AdellijkeTitelPredicaat.Map(),
                Voorletters = naam.Voorletters(),
                Voornamen = naam.Voornamen,
                VolledigeNaam = naam.VolledigeNaam(geslacht),
                Voorvoegsel = naam.Voorvoegsel,
                Geslachtsnaam = naam.Geslachtsnaam == "."
                ? null
                : naam.Geslachtsnaam
            };
    }

    public static NaamGerelateerde? MapNaamGerelateerde(this CommonDtos.NaamBasis? naam)
    {
        return naam == null
            ? null
            : new NaamGerelateerde
            {
                AdellijkeTitelPredicaat = naam.AdellijkeTitelPredicaat.Map(),
                Voorletters = naam.Voorletters(),
                Voornamen = naam.Voornamen,
                Voorvoegsel = naam.Voorvoegsel,
                Geslachtsnaam = naam.Geslachtsnaam == "."
                ? null
                : naam.Geslachtsnaam
            };
    }

    public static NaamPersoon? Map(this BrpDtos.GbaNaamPersoon? naam)
    {
        return naam == null
            ? null
            : new NaamPersoon
            {
                AanduidingNaamgebruik = naam.AanduidingNaamgebruik.Map(),
                AdellijkeTitelPredicaat = naam.AdellijkeTitelPredicaat.Map(),
                Voorletters = naam.Voorletters(),
                Voornamen = naam.Voornamen,
                VolledigeNaam = naam.VolledigeNaam(null),
                Voorvoegsel = naam.Voorvoegsel,
                Geslachtsnaam = naam.Geslachtsnaam == "."
                ? null
                : naam.Geslachtsnaam,
                Partners = naam.Partners?.Map()
            };
    }

    private static Collection<Partner>? Map(this ICollection<BrpDtos.GbaPartner> partners)
    {
        var retval = new Collection<Partner>();
        foreach(var partner in partners)
        {
            if (partner != null)
            {
                retval.Add(partner.Map()!);
            }
        }
        return retval;
    }

    public static NaamVolledigeNaam? MapNaamVolledigeNaam(this CommonDtos.NaamBasis? naam, CommonDtos.Waardetabel geslacht)
    {
        return naam == null
            ? null
            : new NaamVolledigeNaam
            {
                VolledigeNaam = naam.VolledigeNaam(geslacht)
            };
    }
}
