﻿using Brp.Shared.Validatie.Validators;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Historie;

public class RaadpleegMetPeriodeQueryValidator : AbstractValidator<JObject>
{
    public RaadpleegMetPeriodeQueryValidator()
    {
        Include(new NietGespecificeerdeParametersValidator(GespecificeerdeParameterNamen));
        Include(new BurgerservicenummerValidator(true));
        Include(new PeriodeValidator("datumVan", "datumTot"));
    }

    private readonly List<string> GespecificeerdeParameterNamen = new()
    {
        "type",
        "burgerservicenummer",
        "datumVan",
        "datumTot"
    };
}
