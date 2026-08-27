using Brp.Shared.DtoMappers.Mappers;

namespace Brp.Shared.DtoMappers.Profiles
{
    public static class ImmigratieInOnderzoekExtensions
    {
        public static BrpApiDtos.ImmigratieInOnderzoek? ImmigratieInOnderzoek(this BrpDtos.InOnderzoek? source)
        {
            if(source == null)
            {
                return null;
            }

            return source?.AanduidingGegevensInOnderzoek switch
            {
                "080000" or
                "081400" => new BrpApiDtos.ImmigratieInOnderzoek
                {
                    LandVanwaarIngeschreven = true,
                    DatumVestigingInNederland = true,
                    IndicatieVestigingVanuitBuitenland = true,
                    VanuitVerblijfplaatsOnbekend = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
                },
                "081410" => new BrpApiDtos.ImmigratieInOnderzoek
                {
                    LandVanwaarIngeschreven = true,
                    VanuitVerblijfplaatsOnbekend = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
                },
                "081420" => new BrpApiDtos.ImmigratieInOnderzoek
                {
                    DatumVestigingInNederland = true,
                    IndicatieVestigingVanuitBuitenland = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek.Map()
                },
                _ => null,
            };
        }
    }
}