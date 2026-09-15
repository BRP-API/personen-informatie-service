using HaalCentraal.BrpService.Generated;
using HaalCentraal.BrpService.Repositories;
using System.Text.RegularExpressions;

namespace HaalCentraal.BrpService.Profiles;

public static class ZoekMetPostcodeEnHuisnummerMapper
{
    public static ZoekMetPostcodeEnHuisnummerFilter Map(this ZoekMetPostcodeEnHuisnummer src)
    {
        return new ZoekMetPostcodeEnHuisnummerFilter
        {
            InclusiefOverledenPersonen = src.InclusiefOverledenPersonen ?? false,
            Huisletter = src.Huisletter,
            Huisnummer = int.Parse(src.Huisnummer!),
            Huisnummertoevoeging = src.Huisnummertoevoeging,
            Postcode = Regex.Replace(src.Postcode!.ToUpperInvariant(), @"\s+", "", RegexOptions.None, TimeSpan.FromMilliseconds(100)),
            Geboortedatum = !string.IsNullOrEmpty(src.Geboortedatum) ? DateTimeOffset.Parse(src.Geboortedatum!) : null,
            Geslachtsnaam = src.Geslachtsnaam,
            GemeenteVanInschrijving = src.GemeenteVanInschrijving,
        };
    }
}
