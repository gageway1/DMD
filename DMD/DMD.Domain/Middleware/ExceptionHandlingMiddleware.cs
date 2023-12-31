﻿using DMD.Data.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace DMD.Domain.Middleware
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception, httpContext);

            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception, HttpContext context) =>
            exception switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                NotFoundInDbOkException => (int)HttpStatusCode.OK,
                BandNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.Source ?? "[No Source Found]",
                ValidationException => "[Bad Request]",
                NotFoundInDbOkException => "[No entry found]",
                BandNotFoundException => "[No band found]",
                _ => "Server Error"
            };

        private static IEnumerable<ValidationFailure> GetErrors(Exception exception)
        {
            IEnumerable<ValidationFailure> errors = new List<ValidationFailure>();
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
