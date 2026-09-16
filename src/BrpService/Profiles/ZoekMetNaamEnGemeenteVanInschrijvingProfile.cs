using HaalCentraal.BrpService.Generated;
using HaalCentraal.BrpService.Repositories;

namespace HaalCentraal.BrpService.Profiles;

public static class ZoekMetNaamEnGemeenteVanInschrijvingMapper
{
    public static ZoekMetNaamEnGemeenteVanInschrijvingFilter Map(this ZoekMetNaamEnGemeenteVanInschrijving src)
    {
        return new ZoekMetNaamEnGemeenteVanInschrijvingFilter
        {
            InclusiefOverledenPersonen = src.InclusiefOverledenPersonen ?? false,
            Geslachtsaanduiding = src.Geslacht,
            Geslachtsnaam = src.Geslachtsnaam,
            Voorvoegsel = src.Voorvoegsel,
            Voornamen = src.Voornamen,
            GemeenteVanInschrijving = src.GemeenteVanInschrijving,
        };
    }
}
