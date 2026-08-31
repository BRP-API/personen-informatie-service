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

    public static Geboorte? Map(this BrpDtos.GbaGeboorte? geboorte)
    {
        return geboorte == null
            ? null
            : new Geboorte
            {
                Datum = geboorte.Datum?.Map(),
                Plaats = geboorte.Plaats?.Code == "0000"
                    ? null
                    : geboorte.Plaats?.Map(),
                Land = geboorte.Land?.Code == "0000"
                    ? null
                    : geboorte.Land?.Map()
            };
    }
}
