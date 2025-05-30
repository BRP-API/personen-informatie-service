﻿using AutoMapper;
using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.Mappers;

namespace BrpProxy.Profiles;

public class PartnerInOnderzoekConverter : ITypeConverter<Brp.Shared.DtoMappers.BrpDtos.InOnderzoek, PartnerInOnderzoek?>
{
    public PartnerInOnderzoek? Convert(Brp.Shared.DtoMappers.BrpDtos.InOnderzoek source, PartnerInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "050000" => new PartnerInOnderzoek
            {
                Burgerservicenummer = true,
                SoortVerbintenis = true,
                Geslacht = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "050100" or "050120" => new PartnerInOnderzoek
            {
                Burgerservicenummer = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "050400" or "050410" => new PartnerInOnderzoek
            {
                Geslacht = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "051500" or "051510" => new PartnerInOnderzoek
            {
                SoortVerbintenis = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            _ => null,
        };
    }
}
