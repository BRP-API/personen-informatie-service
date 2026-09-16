using HaalCentraal.BrpService.Generated;
using HaalCentraal.BrpService.Repositories;

namespace HaalCentraal.BrpService.Profiles;

public static class ZoekMetGeslachtsnaamEnGeboortedatumMapper
{
    public static ZoekMetGeslachtsnaamEnGeboortedatumFilter Map(this ZoekMetGeslachtsnaamEnGeboortedatum src)
    {
        return new ZoekMetGeslachtsnaamEnGeboortedatumFilter
        {
            InclusiefOverledenPersonen = src.InclusiefOverledenPersonen ?? false,
            Geboortedatum = DateTimeOffset.Parse(src.Geboortedatum!),
            Geslachtsnaam = src.Geslachtsnaam!,
            Geslachtsaanduiding = src.Geslacht,
            Voorvoegsel = src.Voorvoegsel,
            Voornamen = src.Voornamen,
            GemeenteVanInschrijving = src.GemeenteVanInschrijving
        };
    }
}
