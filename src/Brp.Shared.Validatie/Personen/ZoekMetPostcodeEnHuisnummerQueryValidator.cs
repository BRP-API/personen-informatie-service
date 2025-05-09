﻿using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Personen;

public class ZoekMetPostcodeEnHuisnummerQueryValidator : AbstractValidator<JObject>
{
    public ZoekMetPostcodeEnHuisnummerQueryValidator()
    {
        Include(new PostcodeVerplichtValidator());
        Include(new HuisnummerVerplichtValidator());
        Include(new HuisletterValidator());
        Include(new HuisnummertoevoegingValidator());
        Include(new InclusiefOverledenPersonenOptioneelValidator());
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new FieldsValidator(Constanten.PersoonBeperktFields, Constanten.NotAllowedPersoonFields, 130));
        Include(new DatumValidator(parameterNaam: "geboortedatum", isVerplichtVeld: false));
        Include(new GeslachtsnaamValidator(isVerplichtVeld: false));
        Include(new GemeenteVanInschrijvingValidator());
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "postcode",
        "huisnummer",
        "huisletter",
        "huisnummertoevoeging",
        "inclusiefOverledenPersonen",
        "gemeenteVanInschrijving",
        "fields",
        "geboortedatum",
        "geslachtsnaam"
    };
}
