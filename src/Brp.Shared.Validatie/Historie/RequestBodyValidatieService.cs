﻿using Brp.Shared.Validatie.Handlers;
using Brp.Shared.Validatie.Validators;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;

namespace Brp.Shared.Validatie.Historie;

public class RequestBodyValidatieService : IRequestBodyValidator
{
    public ValidationResult ValidateRequestBody(string requestBody)
    {
        var input = JObject.Parse(requestBody);
        return input.Value<string>("type") switch
        {
            "RaadpleegMetPeildatum" => new RaadpleegMetPeildatumQueryValidator().Validate(input),
            "RaadpleegMetPeriode" => new RaadpleegMetPeriodeQueryValidator().Validate(input),
            _ => new RequestBodyValidator(new string[]
            {
                "RaadpleegMetPeildatum",
                "RaadpleegMetPeriode"
            }).Validate(input)
        };
    }
}
