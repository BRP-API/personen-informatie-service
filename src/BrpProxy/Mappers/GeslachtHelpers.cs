using HaalCentraal.BrpProxy.Generated;
using Brp.Shared.DtoMappers.Mappers;
namespace BrpProxy.Mappers;

public static class GeslachtHelpers
{
    public static bool IsVrouw(this NaamPersoon naam) => naam.Geslacht.IsVrouw();

    public static bool IsMan(this Partner? partner) => partner != null && partner.Geslacht.IsMan();

    public static bool IsMan(this NaamPersoon naam) => naam.Geslacht.IsMan();

    public static string? Geslacht(this NaamPersoon persoon) => persoon.Geslacht?.Code.ToUpperInvariant();
}
