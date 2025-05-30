﻿using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class StaatloosInOnderzoekConverter : ITypeConverter<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, StaatloosInOnderzoek?>
{
    public StaatloosInOnderzoek? Convert(Brp.Shared.DtoMappers.BrpDtos.InOnderzoek source, StaatloosInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "040000" => new StaatloosInOnderzoek
            {
                RedenOpname = true,
                Type = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "040500" or
            "040510" or
            "046500" or
            "046510" => new StaatloosInOnderzoek
            {
                Type = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()

            },
            "046300" or "046310" => new StaatloosInOnderzoek
            {
                RedenOpname = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()

            },
            _ => null
        };
    }
}
