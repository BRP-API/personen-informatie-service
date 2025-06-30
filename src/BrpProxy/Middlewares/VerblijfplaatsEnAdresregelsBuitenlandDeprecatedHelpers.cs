using HaalCentraal.BrpProxy.Generated.Deprecated;

namespace BrpProxy.Middlewares;

public static class VerblijfplaatsEnAdresregelsBuitenlandDeprecatedHelpers
{
    public static ICollection<Persoon> ExcludeAdresregelsEnVerblijfplaatsBuitenland(this ICollection<Persoon> personen, IList<string> fields)
    {
        var retval = new List<Persoon>();

        foreach(var p in personen)
        {
            p.ClearBuitenlandsAdresseringEnVerblijfplaatsBijBinnenlandseBevraging(fields);

            retval.Add(p);
        }

        return retval;
    }
}
