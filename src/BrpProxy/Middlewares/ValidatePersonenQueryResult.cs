using HaalCentraal.BrpProxy.Generated;
using FluentValidation.Results;

namespace BrpProxy.Middlewares
{
    public class ValidatePersonenQueryResult
    {
        private static InvalidParam? CreateFrom(string propertyName, string errorMessage)
        {
            var messages = errorMessage.Split("||");
            switch(messages.Length)
            {
                case 2:
                    return new InvalidParam
                    {
                        Name = $"{char.ToLowerInvariant(propertyName[0])}{propertyName[1..]}",
                        Code = messages[0],
                        Reason = messages[1]
                    };
                case 3:
                    return new InvalidParam
                    {
                        Name = messages[0],
                        Code = messages[1],
                        Reason = messages[2]
                    };
                default:
                    return null;
            }
        }
        public static ValidatePersonenQueryResult CreateFrom(ValidationResult result, ICollection<string>? fields, HttpContext context)
        {
            if (result.IsValid)
            {
                return new ValidatePersonenQueryResult(fields);
            }

            var invalidParams = from error in result.Errors
                                select CreateFrom(error.PropertyName, error.ErrorMessage);
            var titel = "Een of meerdere parameters zijn niet correct.";
            var code = "paramsValidation";

            return new ValidatePersonenQueryResult(context.CreateBadRequestFoutbericht(titel, code, invalidParams));
        }

        public static ValidatePersonenQueryResult CreateFrom(ValidationResult result, HttpContext context)
        {
            var invalidParams = from error in result.Errors
                                select new InvalidParam
                                {
                                    Name = "type",
                                    Code = error.ErrorMessage.Split("||")[0],
                                    Reason = error.ErrorMessage.Split("||")[1]
                                };
            var titel = "Een of meerdere parameters zijn niet correct.";
            var code = "paramsValidation";

            return new ValidatePersonenQueryResult(context.CreateBadRequestFoutbericht(titel, code, invalidParams));
        }

        private ValidatePersonenQueryResult(ICollection<string>? fields)
        {
            IsValid = true;
            Fields = fields;
        }

        private ValidatePersonenQueryResult(BadRequestFoutbericht foutbericht)
        {
            IsValid = false;
            Foutbericht = foutbericht;
        }

        public bool IsValid { get; }
        public ICollection<string>? Fields { get; }
        public BadRequestFoutbericht? Foutbericht { get; }
    }
}
