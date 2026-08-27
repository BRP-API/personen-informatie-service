namespace Brp.Shared.DtoMappers.Mappers;

public static class VerblijfstitelMapper
{
    public static BrpApiDtos.Verblijfstitel? Map(this BrpDtos.GbaVerblijfstitel? verblijfstitel)
    {
        if (verblijfstitel == null)
        {
            return null;
        }
        return new BrpApiDtos.Verblijfstitel
        {
            Aanduiding = verblijfstitel.Aanduiding?.Code == "98" ? null : verblijfstitel.Aanduiding,
            DatumEinde = verblijfstitel.DatumEinde.Map(),
            DatumIngang = verblijfstitel.DatumIngang.Map(),
            InOnderzoek = verblijfstitel.InOnderzoek.VerblijfstitelInOnderzoek()
        };
    }

    private static BrpApiDtos.VerblijfstitelInOnderzoek? VerblijfstitelInOnderzoek(this BrpDtos.InOnderzoek? source)
    {
        if (source == null)
        {
            return null;
        }

        BrpApiDtos.VerblijfstitelInOnderzoek? retval = source.AanduidingGegevensInOnderzoek switch
        {
            "100000" or "103900" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding = true,
                DatumIngang = true,
                DatumEinde = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103910" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                Aanduiding = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103920" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumEinde = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            "103930" => new BrpApiDtos.VerblijfstitelInOnderzoek
            {
                DatumIngang = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
            },
            _ => null,
        };

        return retval;
    }
}
