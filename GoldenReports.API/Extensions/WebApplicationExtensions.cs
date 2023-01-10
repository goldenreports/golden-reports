using System.Net.Mime;
using GoldenReports.API.Resources;
using GoldenReports.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace GoldenReports.API.Extensions;

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
}