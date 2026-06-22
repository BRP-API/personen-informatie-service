using HaalCentraal.BrpService.Generated;
using System.Linq.Expressions;

namespace HaalCentraal.BrpService.Repositories;

public class GemeenteVanInschrijvingGbaPersoonSpecification : Specification<GbaPersoon>
{
    private readonly string _gemeenteVanInschrijving;

    public GemeenteVanInschrijvingGbaPersoonSpecification(string gemeenteVanInschrijving)
    {
        _gemeenteVanInschrijving = gemeenteVanInschrijving;
    }

    public override Expression<Func<GbaPersoon, bool>> ToExpression()
    {
        return persoon => persoon != null &&
               persoon.GemeenteVanInschrijving != null &&
               persoon.GemeenteVanInschrijving.Code == _gemeenteVanInschrijving;
    }
}
