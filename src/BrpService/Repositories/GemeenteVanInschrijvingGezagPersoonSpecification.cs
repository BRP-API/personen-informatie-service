using HaalCentraal.BrpService.Generated;
using System.Linq.Expressions;

namespace HaalCentraal.BrpService.Repositories;

public class GemeenteVanInschrijvingGezagPersoonSpecification : Specification<GbaGezagPersoonBeperkt>
{
    private readonly string _gemeenteVanInschrijving;

    public GemeenteVanInschrijvingGezagPersoonSpecification(string gemeenteVanInschrijving)
    {
        _gemeenteVanInschrijving = gemeenteVanInschrijving;
    }

    public override Expression<Func<GbaGezagPersoonBeperkt, bool>> ToExpression()
    {
        return persoon => persoon != null &&
               persoon.GemeenteVanInschrijving != null &&
               persoon.GemeenteVanInschrijving.Code == _gemeenteVanInschrijving;
    }
}
