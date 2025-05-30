﻿using Brp.Shared.DtoMappers.BrpApiDtos;
using Brp.Shared.DtoMappers.CommonDtos;
using Brp.Shared.DtoMappers.Interfaces;

namespace BrpProxy.Mappers;

public static class AdellijkeTitelPredicaatHelpers
{
    private const string BARONES = "barones";
    private const string BARON = "baron";
    private const string GRAVIN = "gravin";
    private const string GRAAF = "graaf";
    private const string HERTOGIN = "hertogin";
    private const string HERTOG = "hertog";
    private const string MARKIEZIN = "markiezin";
    private const string MARKIES = "markies";
    private const string PRINSES = "prinses";
    private const string PRINS = "prins";
    private const string RIDDER = "ridder";

    private const string JONKVROUW = "jonkvrouw";
    private const string JONKHEER = "jonkheer";

    private const string HOOGWELGEBORENHEER = "Hoogwelgeboren heer";
    private const string HOOGWELGEBORENVROUWE = "Hoogwelgeboren vrouwe";
    private const string HOOGGEBORENHEER = "Hooggeboren heer";
    private const string HOOGGEBORENVROUWE = "Hooggeboren vrouwe";
    private const string HOOGHEID = "Hoogheid";

    private static readonly Dictionary<string, string> AdellijkeTitels = new()
    {
        { "B", BARON },
        { "BS", BARONES },
        { "G", GRAAF },
        { "GI", GRAVIN },
        { "H", HERTOG },
        { "HI", HERTOGIN },
        { "M", MARKIES },
        { "MI", MARKIEZIN },
        { "P", PRINS },
        { "PS", PRINSES },
        { "R", RIDDER }
    };

    private static readonly Dictionary<string, string> Predicaten = new()
    {
        { "JH", JONKHEER },
        { "JV", JONKVROUW }
    };

    private static readonly Dictionary<string, string> HoffelijkheidsTitels = new()
    {
        { "B", HOOGWELGEBORENVROUWE },
        { "G", HOOGGEBORENVROUWE },
        { "H", HOOGWELGEBORENVROUWE },
        { "M", HOOGWELGEBORENVROUWE },
        { "P", HOOGHEID }
    };

    private static readonly Dictionary<string, string> AanhefAdellijkeTitelPredicaat = new()
    {
        { "B-M", HOOGWELGEBORENHEER },
        { "BS-M", HOOGWELGEBORENHEER },
        { "B-V", HOOGWELGEBORENVROUWE },
        { "BS-V", HOOGWELGEBORENVROUWE },
        { "G-M", HOOGGEBORENHEER },
        { "GI-M", HOOGGEBORENHEER },
        { "G-V", HOOGGEBORENVROUWE },
        { "GI-V", HOOGGEBORENVROUWE },
        { "H-M", HOOGWELGEBORENHEER },
        { "HI-M", HOOGWELGEBORENHEER },
        { "H-V", HOOGWELGEBORENVROUWE },
        { "HI-V", HOOGWELGEBORENVROUWE },
        { "JH-M", HOOGWELGEBORENHEER },
        { "JV-M", HOOGWELGEBORENHEER },
        { "JH-V", HOOGWELGEBORENVROUWE },
        { "JV-V", HOOGWELGEBORENVROUWE },
        { "M-M", HOOGWELGEBORENHEER },
        { "MI-M", HOOGWELGEBORENHEER },
        { "M-V", HOOGWELGEBORENVROUWE },
        { "MI-V", HOOGWELGEBORENVROUWE },
        { "P-M", HOOGHEID },
        { "PS-M", HOOGHEID },
        { "P-V", HOOGHEID },
        { "PS-V", HOOGHEID },
        { "P-O", HOOGHEID },
        { "PS-O", HOOGHEID },
        { "R-M", HOOGWELGEBORENHEER },
        { "R-V", HOOGWELGEBORENVROUWE },
    };

    public static string AdellijkeTitelPredicaat(this NaamPersoon naam) => 
        naam.AdellijkeTitelPredicaat != null
            ? naam.AdellijkeTitelPredicaat.Code
            : string.Empty;

    public static string AdellijkeTitelPredicaat(this Partner? partner) =>
        partner?.Naam?.AdellijkeTitelPredicaat != null
            ? partner.Naam.AdellijkeTitelPredicaat.Code
            : String.Empty;

    public static AdellijkeTitelPredicaatType? AdellijkeTitelPredicaatType(this Partner? partner) =>
        partner?.Naam.AdellijkeTitelPredicaat != null
            ? partner.Naam.AdellijkeTitelPredicaat
            : null;

    public static bool HeeftAdellijkeTitel(this NaamPersoon naam) =>
        naam.AdellijkeTitelPredicaat != null &&
        naam.AdellijkeTitelPredicaat.Code != null &&
        AdellijkeTitels.ContainsKey(naam.AdellijkeTitelPredicaat.Code);

    public static bool HeeftAdellijkeTitel(this Partner? partner) =>
        partner?.Naam?.AdellijkeTitelPredicaat != null &&
        AdellijkeTitels.ContainsKey(partner.Naam.AdellijkeTitelPredicaat.Code);

    public static bool HeeftAdellijkeTitelOfPredicaat(this NaamPersoon persoon) => persoon.AdellijkeTitelPredicaat != null;

    public static bool HeeftAdellijkeTitelOfPredicaat(this Partner? partner) =>
        partner?.Naam?.AdellijkeTitelPredicaat != null;

    public static bool HeeftGeenAdellijkeTitelOfPredicaat(this NaamPersoon persoon) => !persoon.HeeftAdellijkeTitelOfPredicaat();

    public static bool HeeftGeenAdellijkeTitelOfPredicaat(this Partner? partner) => !partner.HeeftAdellijkeTitelOfPredicaat();

    public static bool HeeftAdellijkeTitelMetAanspreekvorm(this NaamPersoon persoon, IWaardetabel? geslacht)
    {
        if (persoon.AdellijkeTitelPredicaat != null &&
            persoon.AdellijkeTitelPredicaat.Code != null &&
            geslacht != null &&
            geslacht?.Code != null)
        {
            var aanhefKey = $"{persoon.AdellijkeTitelPredicaat.Code}-{geslacht.Code}";

            return AanhefAdellijkeTitelPredicaat.ContainsKey(aanhefKey);
        }
        return false;
    }

    public static bool HeeftPredicaat(this NaamPersoon naam) =>
        !string.IsNullOrWhiteSpace(naam.AdellijkeTitelPredicaat?.Code) &&
        Predicaten.ContainsKey(naam.AdellijkeTitelPredicaat.Code);

    public static bool HeeftHoffelijkheidstitelMetAanspreekvorm(this Partner? partner) =>
        partner != null &&
        HoffelijkheidsTitels.ContainsKey(partner.AdellijkeTitelPredicaat());

    public static string BepaalHoffelijkheidstitel(this Partner? partner) => HoffelijkheidsTitels[partner.AdellijkeTitelPredicaat()];

    public static bool HeeftGeenAdellijkeTitelMetAanspreekvorm(this NaamPersoon persoon, IWaardetabel geslacht) => !persoon.HeeftAdellijkeTitelMetAanspreekvorm(geslacht);

    private static bool HeeftHoffelijkheidsTitel(this NaamPersoon naam) =>
        !string.IsNullOrWhiteSpace(naam.AdellijkeTitelPredicaat.Code) &&
        HoffelijkheidsTitels.ContainsKey(naam.AdellijkeTitelPredicaat.Code);

    public static bool HeeftGeenHoffelijkheidsTitel(this NaamPersoon naam) => !naam.HeeftHoffelijkheidsTitel();

    public static string BepaalAanhefVoorAdellijkeTitelOfPredicaat(this NaamPersoon persoon, IWaardetabel geslacht)
    {
        var aanhefKey = $"{persoon.AdellijkeTitelPredicaat.Code}-{geslacht.Code}";

        return AanhefAdellijkeTitelPredicaat[aanhefKey];
    }


    public static string Titel(this Partner? partner, NaamPersoon persoon, IDictionary<string, string> adellijkeTitelsEnPredicaten, IWaardetabel? geslacht)
    {
        if (partner == null) return string.Empty;

        var keyPartner = partner.HeeftAdellijkeTitelOfPredicaat()
            ? $"{partner.AdellijkeTitelPredicaat()}-{geslacht.Geslacht()}"
            : null;

        return keyPartner != null && adellijkeTitelsEnPredicaten.ContainsKey(keyPartner)
            ? adellijkeTitelsEnPredicaten[keyPartner]
            : string.Empty;
    }

    public static string Titel(this NaamPersoon persoon, IDictionary<string, string> adellijkeTitelsEnPredicaten, IWaardetabel? geslacht)
    {
        var key = $"{persoon.AdellijkeTitelPredicaat()}-{geslacht.Geslacht()}";

        return adellijkeTitelsEnPredicaten.ContainsKey(key)
            ? adellijkeTitelsEnPredicaten[key]
            : string.Empty;
    }
}
