﻿using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Mappers;

public static class NaamMapper
{
    public static bool HeeftLeegOfOnbekendGeslachtsnaam(this NaamPersoon naam) => string.IsNullOrWhiteSpace(naam.Geslachtsnaam);

    public static bool IsLeegOfOnbekend(this string partnerNaam) => string.IsNullOrWhiteSpace(partnerNaam);

    public static string? ToNull(this string? str)
    {
        return string.IsNullOrWhiteSpace(str) ? null : str;
    }

    public static string? Capitalize(this string? str)
    {
        return !string.IsNullOrWhiteSpace(str)
            ? str.Length switch
        {
            1 => str.ToUpperInvariant(),
            _ => $"{char.ToUpperInvariant(str[0])}{str[1..]}"
        }
        : str;
    }

    public static string Achternaam(this Partner? partner)
    {
        return partner != null
            ? partner.Naam.Achternaam()
            : string.Empty;
    }
}
