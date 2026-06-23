using HaalCentraal.BrpService.Generated;
using System.Linq.Expressions;

namespace HaalCentraal.BrpService.Repositories;

public class GemeenteVanInschrijvingSpecification<T>(string gemeenteVanInschrijving)
    : Specification<T> where T : IPersonenQueryParameters
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return persoon => !object.Equals(persoon, default(T)) &&
               persoon.GemeenteVanInschrijving != null &&
               persoon.GemeenteVanInschrijving.Code == gemeenteVanInschrijving;
    }
}
