﻿using AutoMapper;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.BrpProxy.Generated;

namespace BrpProxy.Profiles;

public class NaamPersoonInOnderzoekConverter : ITypeConverter<HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek, NaamPersoonInOnderzoek?>
{
    public NaamPersoonInOnderzoek? Convert(HaalCentraal.BrpProxy.Generated.Gba.InOnderzoek source, NaamPersoonInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "010000" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                AanduidingNaamgebruik = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010200" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                AdellijkeTitelPredicaat = true,
                Voorvoegsel = true,
                Geslachtsnaam = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010210" => new NaamPersoonInOnderzoek
            {
                Voornamen = true,
                Voorletters = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010220" => new NaamPersoonInOnderzoek
            {
                AdellijkeTitelPredicaat = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010230" => new NaamPersoonInOnderzoek
            {
                Voorvoegsel = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010240" => new NaamPersoonInOnderzoek
            {
                Geslachtsnaam = true,
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "010400" or "010410" => new NaamPersoonInOnderzoek
            {
                VolledigeNaam = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            "016100" or "016110" => new NaamPersoonInOnderzoek
            {
                AanduidingNaamgebruik = true,
                DatumIngangOnderzoek = source?.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}
