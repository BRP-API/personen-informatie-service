﻿using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.ProblemDetails;
using Microsoft.AspNetCore.Http;

namespace Brp.Shared.Validatie.Handlers;

public static class NotFoundHandler
{
    public static async ValueTask<bool> HandleNotFound(this HttpContext context, Stream? orgBodyStream = null)
    {
        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            var problemDetails = context.Request.CreateProblemDetailsFor(StatusCodes.Status404NotFound);

            if (orgBodyStream != null)
            {
                context.Response.Body = orgBodyStream;
            }
            await context.Response.WriteProblemDetailsAsync(problemDetails);

            return false;
        }

        return true;
    }
}
