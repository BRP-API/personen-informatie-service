﻿using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using BrpApiDtos = Brp.Shared.DtoMappers.BrpApiDtos;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;

namespace BrpProxy.Profiles;

public class KindInOnderzoekConverter : ITypeConverter<BrpDtos.InOnderzoek, BrpApiDtos.KindInOnderzoek?>
{
    public BrpApiDtos.KindInOnderzoek? Convert(BrpDtos.InOnderzoek source, BrpApiDtos.KindInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "090000" or
            "090100" or
            "090120" => new BrpApiDtos.KindInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
