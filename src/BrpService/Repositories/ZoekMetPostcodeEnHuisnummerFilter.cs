namespace HaalCentraal.BrpService.Repositories;

public class ZoekMetPostcodeEnHuisnummerFilter
{
    public bool InclusiefOverledenPersonen { get; set; }
    public string? Huisletter { get; set; }
    public int Huisnummer { get; set; }
    public string? Huisnummertoevoeging { get; set; }
    public string Postcode { get; set; } = string.Empty;
    public DateTimeOffset? Geboortedatum { get; set; }
    public string? Geslachtsnaam { get; set; }
}
