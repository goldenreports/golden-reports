using System.Net.Mime;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.Exceptions;
using GoldenReports.WebUI.Configuration;
using Microsoft.AspNetCore.Diagnostics;

namespace GoldenReports.WebUI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseGlobalExceptionHandler(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    // var logger = context.RequestServices.GetRequiredService<>()
                    var responseContent = new ErrorDto(context.Response.StatusCode,
                        contextFeature.Error.Message);
                    responseContent.ErrorCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => responseContent.ErrorCode
                    };

                    context.Response.StatusCode = responseContent.ErrorCode;
                    await context.Response.WriteAsJsonAsync(responseContent);
                }
            });
        });
        return webApplication;
    }

    public static WebApplication UseApiSwagger(this WebApplication app)
    {
        var appSettings = app.Configuration.Get<AppSettings>();
        if (appSettings?.Swagger.Enabled != true)
        {
            return app;
        }

        var swaggerSettings = appSettings.Swagger;
        app.UseSwagger();
        app.UseSwaggerUI(opts =>
        {
            opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1.0");

            if (swaggerSettings.OAuthFlows == null)
            {
                return;
            }

            if (swaggerSettings.ClientId != null)
            {
                opts.OAuthClientId(swaggerSettings.ClientId);
            }

            if (swaggerSettings.UsePkce)
            {
                opts.OAuthUsePkce();
            }

            if (swaggerSettings.ClientSecret != null)
            {
                opts.OAuthClientSecret(swaggerSettings.ClientSecret);
            }

            opts.OAuthAppName("Golden Reports API");
            opts.OAuthScopeSeparator(" ");
        });

        return app;
    }
}