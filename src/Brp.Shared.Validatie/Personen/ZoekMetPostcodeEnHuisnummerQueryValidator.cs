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
        Include(new GeboortedatumOptioneelValidator());
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
        "geboortedatum"
    };
}
