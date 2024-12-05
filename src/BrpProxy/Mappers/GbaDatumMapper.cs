using Brp.Shared.DtoMappers.BrpApiDtos;

namespace BrpProxy.Mappers;

public static class GbaDatumMapper
{
    public static int? Leeftijd(this AbstractDatum datum)
    {
        return datum switch
        {
            VolledigeDatum d => d.Datum!.Value.LocalDateTime.Leeftijd(DateTime.Today),
            JaarMaandDatum d => d.Leeftijd(DateTime.Today),
            _ => null
        };
    }

    public static int Leeftijd(this DateTime datum, DateTime peildatum)
    {
        var leeftijd = peildatum.Year - datum.Year;

        if(peildatum.Month < datum.Month ||
            (peildatum.Month == datum.Month && peildatum.Day < datum.Day))
        {
            leeftijd--;
        }

        return leeftijd;
    }

    public static int? Leeftijd(this JaarMaandDatum datum, DateTime peildatum)
    {
        return datum.Maand != peildatum.Month
            ? new DateTime(datum.Jaar!.Value, datum.Maand!.Value, 1, 0, 0, 0, DateTimeKind.Local).Leeftijd(peildatum)
            : null;
    }
}
