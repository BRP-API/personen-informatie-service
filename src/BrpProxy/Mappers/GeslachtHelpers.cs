using Brp.Shared.DtoMappers.Interfaces;

namespace BrpProxy.Mappers;

public static class GeslachtHelpers
{
    public static string? Geslacht(this IWaardetabel? geslacht) => geslacht?.Code.ToUpperInvariant();
}
