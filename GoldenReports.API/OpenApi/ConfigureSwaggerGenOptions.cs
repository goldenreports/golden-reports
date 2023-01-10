using GoldenReports.API.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GoldenReports.API.OpenApi;

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly AppSettings settings;

    public ConfigureSwaggerGenOptions(IOptions<AppSettings> settings)
    {
        this.settings = settings.Value;
    }

    public void Configure(SwaggerGenOptions options)
    {
        options.OperationFilter<AuthorizeOperationFilter>();
        options.SupportNonNullableReferenceTypes();
        options.DescribeAllParametersInCamelCase();
        options.SwaggerDoc("v1", this.CreateOpenApiInfo());

        if (this.settings.Swagger.OAuthFlows != null)
        {
            this.AddOAuthSecurity(options);
        }
        else
        {
            this.AddJwtSecurity(options);
        }
    }
    
    private OpenApiInfo CreateOpenApiInfo()
    {
        return new OpenApiInfo
        {
            Version = "v1",
            Title = "Golden Reports API",
            Description = "Golden Reports API",
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://github.com/santoro-mariano/golden-reports/blob/main/LICENSE")
            }
        };
    }

    private void AddJwtSecurity(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(SecurityDefinitions.Jwt, new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security",
        });
    }

    private void AddOAuthSecurity(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(SecurityDefinitions.OAuth2, new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Description = "OAuth2 based security",
            Flows =  this.settings.Swagger.OAuthFlows
        });
    }
}