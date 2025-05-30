﻿using System.Text;
using System.Text.RegularExpressions;
using Brp.Shared.DtoMappers.Interfaces;
using BrpDtos = Brp.Shared.DtoMappers.BrpDtos;
using CommonDtos = Brp.Shared.DtoMappers.CommonDtos;

namespace BrpProxy.Mappers;

public static class AdresregelsMapper
{
    private static bool StraatHeeftStandaardWaarde(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats) =>
        string.IsNullOrWhiteSpace(verblijfplaats.Straat) || verblijfplaats.Straat == ".";
    private static bool HuisnummerHeeftStandaardWaarde(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats) =>
        !verblijfplaats.Huisnummer.HasValue || verblijfplaats.Huisnummer.Value == 0;
    private static bool LandHeeftStandaardWaarde(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats) =>
        verblijfplaats.Land == null || verblijfplaats.Land.Code == "0000";
    private static bool RegelsHebbenStandaardWaarde(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats) =>
        string.IsNullOrWhiteSpace(verblijfplaats.Regel1) &&
        string.IsNullOrWhiteSpace(verblijfplaats.Regel2) &&
        string.IsNullOrWhiteSpace(verblijfplaats.Regel3);

    public static string? Adresregel1(this BrpDtos.GbaVerblijfplaatsBeperkt? verblijfplaats)
    {
        if (verblijfplaats == null) return null;

        if (!verblijfplaats.StraatHeeftStandaardWaarde() && !verblijfplaats.HuisnummerHeeftStandaardWaarde())
        {
            return verblijfplaats.AdresToAdresregel1();
        }
        if (!string.IsNullOrWhiteSpace(verblijfplaats.Locatiebeschrijving))
        {
            return verblijfplaats.LocatieToAdresregel1();
        }
        if (!string.IsNullOrWhiteSpace(verblijfplaats.Land?.Code))
        {
            return verblijfplaats.VerblijfplaatsBuitenlandToAdresregel1();
        }
        return null;
    }

    private static bool BegintMetCijfer(this string input) => Regex.Match(input, @"^\d.*$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).Success;

    private static string? AdresToAdresregel1(this BrpDtos.GbaVerblijfplaatsBeperkt adres)
    {
        StringBuilder retval = new();

        if (!string.IsNullOrWhiteSpace(adres.Straat))
        {
            retval.Append(adres.Straat);
        }
        if (adres.AanduidingBijHuisnummer != null)
        {
            switch (adres.AanduidingBijHuisnummer.Code)
            {
                case "to":
                    retval.Append(" t/o");
                    break;
                case "by":
                    retval.Append(" bij");
                    break;
                default:
                    break;
            }
        }
        if (adres.Huisnummer > 0)
        {
            retval.AppendFormat("{1}{0}", adres.Huisnummer,
                retval.Length > 0
                    ? " "
                    : "");
        }
        if (!string.IsNullOrWhiteSpace(adres.Huisletter))
        {
            retval.AppendFormat(" {0}", adres.Huisletter);
        }
        if (!string.IsNullOrWhiteSpace(adres.Huisnummertoevoeging))
        {
            if (!string.IsNullOrWhiteSpace(adres.Huisletter))
            {
                retval.Append(adres.Huisnummertoevoeging);
            }
            else
            {
                retval.AppendFormat("{1}{0}", adres.Huisnummertoevoeging,
                    adres.Huisnummertoevoeging.BegintMetCijfer()
                        ? "-"
                        : " ");
            }
        }

        return retval.ToString();
    }

    private static string? LocatieToAdresregel1(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats)
    {
        return verblijfplaats.Locatiebeschrijving;
    }

    private static string? VerblijfplaatsBuitenlandToAdresregel1(this BrpDtos.GbaVerblijfplaatsBeperkt adres) =>
        adres.LandHeeftStandaardWaarde() ||
        adres.RegelsHebbenStandaardWaarde()
            ? null
            : adres.Regel1;

    public static string? Adresregel2(this BrpDtos.GbaVerblijfplaatsBeperkt? verblijfplaats, IWaardetabel gemeenteVanInschrijving)
    {
        if (verblijfplaats == null) return null;

        if (!verblijfplaats.StraatHeeftStandaardWaarde() && !verblijfplaats.HuisnummerHeeftStandaardWaarde())
        {
            return verblijfplaats.AdresToAdresregel2(gemeenteVanInschrijving);
        }
        if (!string.IsNullOrWhiteSpace(verblijfplaats.Locatiebeschrijving))
        {
            return verblijfplaats.LocatieToAdresregel2(gemeenteVanInschrijving);
        }
        if (!string.IsNullOrWhiteSpace(verblijfplaats.Land?.Code))
        {
            return verblijfplaats.VerblijfplaatsBuitenlandToAdresregel2();
        }
        return null;
    }

    private static string? AdresToAdresregel2(this BrpDtos.GbaVerblijfplaatsBeperkt adres, IWaardetabel? gemeenteVanInschrijving)
    {
        if (string.IsNullOrWhiteSpace(adres.Postcode))
        {
            return null;
        }

        var postcodeNum = adres.Postcode != null ? adres.Postcode[0..4] : String.Empty;
        var postcodeAlfa = adres.Postcode != null ? adres.Postcode[4..] : String.Empty;

        return !string.IsNullOrWhiteSpace(adres.Woonplaats)
            ? $"{postcodeNum} {postcodeAlfa}  {adres.Woonplaats.ToUpperInvariant()}"
            : $"{postcodeNum} {postcodeAlfa}  {gemeenteVanInschrijving?.Omschrijving?.ToUpperInvariant()}";
    }

    private static string? LocatieToAdresregel2(this BrpDtos.GbaVerblijfplaatsBeperkt _, IWaardetabel? gemeenteVanInschrijving)
    {
        return gemeenteVanInschrijving?.Omschrijving.ToUpperInvariant();
    }

    private static string? VerblijfplaatsBuitenlandToAdresregel2(this BrpDtos.GbaVerblijfplaatsBeperkt adres) =>
        adres.LandHeeftStandaardWaarde() ||
        adres.RegelsHebbenStandaardWaarde()
            ? null
            : adres.Regel2;

    public static string? Adresregel3(this BrpDtos.GbaVerblijfplaatsBeperkt? adres) =>
        adres == null ||
        adres.LandHeeftStandaardWaarde() ||
        adres.RegelsHebbenStandaardWaarde()
            ? null
            : adres.Regel3;

    public static CommonDtos.Waardetabel? Land(this BrpDtos.GbaVerblijfplaatsBeperkt? adres) =>
        adres == null ||
        adres.LandHeeftStandaardWaarde() ||
        adres.VerblijfplaatsBuitenlandHeeftWaardeNederland() ||
        adres.RegelsHebbenStandaardWaarde()
            ? null
            : new CommonDtos.Waardetabel
            {
                Code = adres.Land.Code,
                Omschrijving = adres.Land.Omschrijving
            };

    private static bool VerblijfplaatsBuitenlandHeeftWaardeNederland(this BrpDtos.GbaVerblijfplaatsBeperkt verblijfplaats) =>
        verblijfplaats.Land != null && verblijfplaats.Land.Code == "6030";

    public static bool? IndicatieVastgesteldVerblijfNietOpAdres(this BrpDtos.GbaVerblijfplaatsBeperkt? verblijfplaats, IAdressering adressering)
    {
        bool isInOnderzoek = verblijfplaats?.InOnderzoek?.AanduidingGegevensInOnderzoek == "089999";

        bool heeftAdresVelden = !string.IsNullOrEmpty(adressering.Adresregel1) || !string.IsNullOrEmpty(adressering.Adresregel2) || !string.IsNullOrEmpty(adressering.Adresregel3) || adressering.Land != null;

        return isInOnderzoek && heeftAdresVelden ? true : null;
    }
}
