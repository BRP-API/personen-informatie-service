﻿using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.Stream;
using HaalCentraal.BrpProxy.Generated;
using Gba = HaalCentraal.BrpProxy.Generated.Gba;
using Newtonsoft.Json;
using AutoMapper;
using BrpProxy.Validators;
using Serilog;
using FluentValidation.Results;
using Brp.Shared.Validatie.Handlers;
using Brp.Shared.Infrastructure.ProblemDetails;

namespace BrpProxy.Middlewares
{
    public class OverwriteResponseBodyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDiagnosticContext _diagnosticContext;
        private readonly IMapper _mapper;
        private readonly FieldsHelper _fieldsHelper;

        public OverwriteResponseBodyMiddleware(RequestDelegate next, IDiagnosticContext diagnosticContext, IMapper mapper, FieldsHelper fieldsHelper)
        {
            _next = next;
            _diagnosticContext = diagnosticContext;
            _mapper = mapper;
            _fieldsHelper = fieldsHelper;
        }

        public async Task Invoke(HttpContext context)
        {
            var orgBodyStream = context.Response.Body;
            string requestBody = string.Empty;
            try
            {
                requestBody = await context.Request.ReadBodyAsync();

                PersonenQuery? personenQuery = null;
                try
                {
                    personenQuery = JsonConvert.DeserializeObject<PersonenQuery>(requestBody);
                }
                catch (JsonSerializationException ex)
                {
                    await context.HandleJsonSerializationException(ex, orgBodyStream, _diagnosticContext);
                    return;
                }
                catch (JsonReaderException ex)
                {
                    await context.HandleJsonReaderException(ex, orgBodyStream, _diagnosticContext);
                    return;
                }

                // deze validatie check is toegevoegd tbv healthcheck
                // tijdens de healthcheck v/d A&P zal deze een GET request sturen om te kijken of de downstream kan worden benaderd
                if(personenQuery is null)
                {
                    var problemDetails = context.Request.CreateProblemDetails(StatusCodes.Status400BadRequest, "De bevraging bevat een fout.", "Request body is geen geldige JSON.");

                    await context.Response.WriteProblemDetailsAsync(problemDetails);

                    return;
                }

                using var newBodyStream = new MemoryStream();
                context.Response.Body = newBodyStream;

                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await context.HandleNotFound(orgBodyStream, _diagnosticContext);
                    return;
                }

                var body = await context.Response.ReadBodyAsync();

                if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
                {
                    _diagnosticContext.Set("original response headers", context.Response.Headers);
                    _diagnosticContext.Set("original response body", body);
                }

                var resultFields = personenQuery is RaadpleegMetBurgerservicenummer
                            ? _fieldsHelper.AddExtraPersoonFields(personenQuery.Fields!)
                            : _fieldsHelper.AddExtraPersoonBeperktFields(personenQuery!.Fields!);

                var modifiedBody = context.Response.StatusCode == StatusCodes.Status200OK
                    ? body.Transform(_mapper, resultFields, personenQuery.Fields!, _diagnosticContext)
                    : body;

                if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
                {
                    _diagnosticContext.Set("transformed responseBody", modifiedBody);
                }

                using var bodyStream = modifiedBody.ToMemoryStream(context.Response.UseGzip());

                context.Response.ContentLength = bodyStream.Length;
                await bodyStream.CopyToAsync(orgBodyStream);
            }
            catch (Exception ex)
            {
                // om onbekend reden wordt een AutomapperMappingException niet gelogd als SetException wordt gebruikt
                _diagnosticContext.Set("exception", ex);

                await context.HandleUnhandledException(requestBody, ex, orgBodyStream, _diagnosticContext);
            }
        }
    }

    internal class DummyRequestBodyValidationService : IRequestBodyValidator
    {
        public ValidationResult ValidateRequestBody(string requestBody)
        {
            return new ValidationResult();
        }
    }

    public static class BrpHelpers
    {
        private static bool IsProxyResponse(this string payload)
        {
            var proxyTokens = new List<string>
            {
                "adressering",
                "\"type\":\"Adres\"",
                "\"type\":\"Locatie\"",
                "\"type\":\"VerblijfplaatsBuitenland\"",
                "\"type\":\"VerblijfplaatsOnbekend\"",
                "langFormaat",
                "\"geheimhoudingPersoonsgegevens\":true",
                "\"vanuitVerblijfplaatsOnbekend\":true",
                "\"indicatieVestigingVanuitBuitenland\":true",
                "voorletters",
                "leeftijd",
                "volledigeNaam",
                "\"type\":\"Nationaliteit\"",
                "BehandeldAlsNederlander",
                "VastgesteldNietNederlander",
                "\"type\":\"Staatloos\"",
                "NationaliteitOnbekend",
                "\"verblijfstitel\":{}"
            };
            return proxyTokens.Exists(t => payload.Contains(t));
        }

        public static string Transform(this string payload, IMapper mapper, ICollection<string> fields, ICollection<string> originalFields, IDiagnosticContext diagnosticContext)
        {
            if(payload.IsProxyResponse())
            {
                diagnosticContext.Set("proxy2proxy aanroep", true);
                return payload;
            }

            PersonenQueryResponse retval;
            var response = JsonConvert.DeserializeObject<Gba.PersonenQueryResponse>(payload);

            switch (response)
            {
                case Gba.RaadpleegMetBurgerservicenummerResponse p:
                    var result = mapper.Map<RaadpleegMetBurgerservicenummerResponse>(p);
                    result.Personen = result.Personen.FilterAfgevoerdePersoon().ExcludeAdresregelsEnVerblijfplaatsBuitenland(originalFields).FilterList(fields);
                    retval = result;
                    break;
                case Gba.ZoekMetGeslachtsnaamEnGeboortedatumResponse pb:
                    var result1 = mapper.Map<ZoekMetGeslachtsnaamEnGeboortedatumResponse>(pb);
                    result1.Personen = result1.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result1;
                    break;
                case Gba.ZoekMetNaamEnGemeenteVanInschrijvingResponse pb:
                    var result3 = mapper.Map<ZoekMetNaamEnGemeenteVanInschrijvingResponse>(pb);
                    result3.Personen = result3.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result3;
                    break;
                case Gba.ZoekMetPostcodeEnHuisnummerResponse pb:
                    var result2 = mapper.Map<ZoekMetPostcodeEnHuisnummerResponse>(pb);
                    result2.Personen = result2.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result2;
                    break;
                case Gba.ZoekMetNummeraanduidingIdentificatieResponse pb:
                    var result4 = mapper.Map<ZoekMetNummeraanduidingIdentificatieResponse>(pb);
                    result4.Personen = result4.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result4;
                    break;
                case Gba.ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse pb:
                    var result5 = mapper.Map<ZoekMetStraatHuisnummerEnGemeenteVanInschrijvingResponse>(pb);
                    result5.Personen = result5.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result5;
                    break;
                case Gba.ZoekMetAdresseerbaarObjectIdentificatieResponse pb:
                    var result6 = mapper.Map<ZoekMetAdresseerbaarObjectIdentificatieResponse>(pb);
                    result6.Personen = result6.Personen.ExcludeAfgevoerdePersoon().FilterList(fields);
                    retval = result6;
                    break;
                default:
                    throw new NotSupportedException();
            }

            return JsonConvert.SerializeObject(retval, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }
    }
}
