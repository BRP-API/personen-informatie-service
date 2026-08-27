using Brp.Shared.DtoMappers.BrpApiDtos;

namespace Brp.Shared.DtoMappers.Mappers;

public static class GeboorteBasisMapper
{
    public static GeboorteBasis? Map(this BrpDtos.GeboorteBasis? geboorteBasis)
    {
        return geboorteBasis == null
            ? null
            : new GeboorteBasis
            {
                Datum = geboorteBasis.Datum.Map()
            };
    }
}
