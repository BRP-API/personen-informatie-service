using Brp.Shared.DtoMappers.BrpApiDtos;

namespace Brp.Shared.DtoMappers.Mappers;

public static class GeboorteMapper
{
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

    private static Brp.Shared.DtoMappers.CommonDtos.Waardetabel? Map(this CommonDtos.Waardetabel? waardetabel)
    {
        return waardetabel == null
            ? null
            : new CommonDtos.Waardetabel
            {
                Code = waardetabel.Code,
                Omschrijving = waardetabel.Omschrijving
            };
    }
}
