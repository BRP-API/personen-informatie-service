using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Interfaces;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Mappers;

public static class AanhefMapper
{
    private static string? BepaalAanhefZonderAdellijkeTitelOfPredicaat(this NaamPersoon persoon, Partner? partner, IWaardetabel? geslacht)
    {
        if (persoon.HeeftLeegOfOnbekendGeslachtsnaam() &&
            persoon.HeeftGeenPartnerNaamgebruik())
        {
            return null;
        }

        var partnerNaam = partner switch
        {
            Partner p => p.Naam.Achternaam(),
            _ => string.Empty
        };
        var persoonNaam = persoon.Achternaam();

        var geslachtsnaam = persoon.AanduidingNaamgebruik?.Code switch
        {
            "E" => persoonNaam,
            "N" => partnerNaam.IsLeegOfOnbekend() ? persoonNaam : $"{persoonNaam}-{partnerNaam}",
            "V" => partnerNaam.IsLeegOfOnbekend() ? persoonNaam : $"{partnerNaam}-{persoonNaam}",
            "P" => partnerNaam.IsLeegOfOnbekend() ? persoonNaam : partnerNaam,
            _ => persoonNaam
        };

        var retval = geslacht.Geslacht() switch
        {
            "M" => $"Geachte heer {geslachtsnaam.Capitalize()}",
            "V" => $"Geachte mevrouw {geslachtsnaam.Capitalize()}",
            "O" => !string.IsNullOrWhiteSpace(persoon.Voorletters)
                ? $"Geachte {persoon.Voorletters} {geslachtsnaam}"
                : $"Geachte {geslachtsnaam.Capitalize()}",
            _ => string.Empty
        };

        return retval.RemoveRedundantSpaces().ToNull();
    }

    public static string? Aanhef(this NaamPersoon? persoon, IWaardetabel geslacht)
    {
        if (persoon == null) return null;

        var partner = persoon.Partners.ActuelePartner();

        if (persoon.IsHoffelijkheidstitel(partner, geslacht))
        {
            return partner.BepaalHoffelijkheidstitel();
        }

        if (persoon.HeeftAdellijkeTitelOfPredicaat())
        {
            if (partner != null &&
                persoon.HeeftPartnerNaamgebruik()
                ) return persoon.BepaalAanhefZonderAdellijkeTitelOfPredicaat(partner, geslacht);

            if (persoon.HeeftPredicaat() &&
                geslacht.IsVrouw() &&
                partner.IsActueelPartner()
                ) return persoon.BepaalAanhefZonderAdellijkeTitelOfPredicaat(partner, geslacht);

            if (persoon.HeeftPredicaat() &&
                geslacht.IsVrouw() &&
                partner.IsExPartner() &&
                persoon.GebruiktNaamVanPartner()
                ) return persoon.BepaalAanhefZonderAdellijkeTitelOfPredicaat(partner, geslacht);

            return persoon.HeeftAdellijkeTitelMetAanspreekvorm(geslacht)
                ? persoon.BepaalAanhefVoorAdellijkeTitelOfPredicaat(geslacht)
                : persoon.BepaalAanhefZonderAdellijkeTitelOfPredicaat(partner, geslacht);
        }

        return persoon.BepaalAanhefZonderAdellijkeTitelOfPredicaat(partner, geslacht);
    }
}
