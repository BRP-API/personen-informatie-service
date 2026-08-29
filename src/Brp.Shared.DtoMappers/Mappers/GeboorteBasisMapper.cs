using Brp.Shared.DtoMappers.BrpApiDtos;

namespace Brp.Shared.DtoMappers.Mappers;

public static class GeboorteBasisMapper
{
    public static GeboorteBeperkt? Map(this BrpDtos.GeboorteBasis? geboorteBasis)
    {
        return geboorteBasis == null
            ? null
            : new GeboorteBeperkt
            {
                Datum = geboorteBasis.Datum?.Map()
            };
    }
}
