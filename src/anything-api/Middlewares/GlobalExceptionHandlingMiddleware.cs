﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace anything_api.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    private readonly Bugsnag.IClient _bugsnag;

    public GlobalExceptionHandlingMiddleware(
        ILogger<GlobalExceptionHandlingMiddleware> logger,
        Bugsnag.IClient bugsnag
    )
    {
        _logger = logger;
        _bugsnag = bugsnag;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            _bugsnag.Notify(ex);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails pd = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "NA",
                Title = "Server Error",
                Detail = "An internal server has ocurred."
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(pd));
        }
    }
}