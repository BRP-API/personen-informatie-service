using AutoMapper;
using BrpProxy.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles
{
    public class ImmigratieInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, ImmigratieInOnderzoek?>
    {
        public ImmigratieInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, ImmigratieInOnderzoek? destination, ResolutionContext context)
        {
            return source?.AanduidingGegevensInOnderzoek switch
            {
                "080000" or
                "081400" => new ImmigratieInOnderzoek
                {
                    LandVanwaarIngeschreven = true,
                    DatumVestigingInNederland = true,
                    IndicatieVestigingVanuitBuitenland = true,
                    VanuitVerblijfplaatsOnbekend = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
                },
                "081410" => new ImmigratieInOnderzoek
                {
                    LandVanwaarIngeschreven = true,
                    VanuitVerblijfplaatsOnbekend = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
                },
                "081420" => new ImmigratieInOnderzoek
                {
                    DatumVestigingInNederland = true,
                    IndicatieVestigingVanuitBuitenland = true,
                    DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
                },
                _ => null,
            };
        }
    }
}