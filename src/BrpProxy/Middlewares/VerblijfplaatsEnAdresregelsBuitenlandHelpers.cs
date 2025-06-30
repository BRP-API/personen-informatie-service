using Brp.Shared.DtoMappers.BrpApiDtos;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Middlewares;

public static class VerblijfplaatsEnAdresregelsBuitenlandHelpers
{
    public static ICollection<Persoon> ExcludeAdresregelsEnVerblijfplaatsBuitenland(this ICollection<Persoon> personen, IList<string> fields)
    {
        var retval = new List<Persoon>();

        foreach (var p in personen)
        {
            fields.ClearBuitenlandsAdresseringEnVerblijfplaatsBijBinnenlandseBevraging(p.Adressering, p.Verblijfplaats);

            retval.Add(p);
        }

        return retval;
    }

    public static void ClearBuitenlandsAdresseringEnVerblijfplaatsBijBinnenlandseBevraging(this IList<string> fields, Adressering? adressering, AbstractVerblijfplaats? verblijfplaats)
    {
        if (fields.AdresseringBinnenlandWordtGevraagdBijBuitenlandsVerblijfplaats(adressering, verblijfplaats))
        {
            adressering.ClearAdresProperties();
        }

        if (fields.VerblijfplaatsBinnenlandWordtGevraagdBijBuitenlandsVerblijfplaats(verblijfplaats))
        {
            verblijfplaats = null;
        }
    }
    
    private static bool AdresseringBinnenlandWordtGevraagdBijBuitenlandsVerblijfplaats(this IList<string> fields, Adressering? adressering, AbstractVerblijfplaats? verblijfplaats) =>
        adressering != null &&
        verblijfplaats is VerblijfplaatsBuitenland &&
        fields.Any(f => f.StartsWith("adresseringBinnenland"));

    private static bool VerblijfplaatsBinnenlandWordtGevraagdBijBuitenlandsVerblijfplaats(this IList<string> fields, AbstractVerblijfplaats? verblijfplaats) =>
        verblijfplaats is VerblijfplaatsBuitenland &&
        fields.Any(f => f.StartsWith("verblijfplaatsBinnenland"));
    
    private static void ClearAdresProperties(this Adressering? adressering)
    {
        if (adressering == null)
        {
            return;
        }
        
        adressering.Adresregel1 = null;
        adressering.Adresregel2 = null;
        adressering.Adresregel3 = null;
        adressering.Land = null;

        if (!adressering.ShouldSerialize())
        {
            adressering = null;
        }
    }
}
