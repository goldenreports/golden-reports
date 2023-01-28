using System.Net;
using GoldenReports.WebUI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GoldenReports.WebUI.OpenApi;

public class AuthorizeOperationFilter : IOperationFilter
{
    private readonly AppSettings settings;

    public AuthorizeOperationFilter(IOptions<AppSettings> settings)
    {
        this.settings = settings.Value;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authAttributes = context.MethodInfo.DeclaringType!.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true)).ToList();

        if (!authAttributes.OfType<AuthorizeAttribute>().Any() ||
            authAttributes.OfType<AllowAnonymousAttribute>().Any())
        {
            return;
        }

        operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(),
            new OpenApiResponse {Description = nameof(HttpStatusCode.Unauthorized)});
        operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(),
            new OpenApiResponse {Description = nameof(HttpStatusCode.Forbidden)});

        operation.Security = new List<OpenApiSecurityRequirement>();

        var securityDefinition = this.settings.Swagger.OAuthFlows != null
            ? SecurityDefinitions.OAuth2
            : SecurityDefinitions.Jwt;

        var oauth2SecurityScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = securityDefinition},
        };


        operation.Security.Add(new OpenApiSecurityRequirement
        {
            [oauth2SecurityScheme] = new[] {securityDefinition}
        });
    }
}