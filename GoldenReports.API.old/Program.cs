using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using GoldenReports.API.Configuration;
using GoldenReports.API.Extensions;
using GoldenReports.API.GraphQL;
using GoldenReports.API.OpenApi;
using GoldenReports.API.Security;
using GoldenReports.Application.Abstractions.Security;
using GoldenReports.Application.Extensions;
using GoldenReports.Persistence.Extensions;
using GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<AppSettings>(builder.Configuration)
    .AddScoped<AppSettings>(x => x.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value)
    .AddScoped<SwaggerSettings>(x => x.GetRequiredService<AppSettings>().Swagger)
    .AddScoped<SecuritySettings>(x => x.GetRequiredService<AppSettings>().Security)
    .AddScoped<GraphQLSettings>(x => x.GetRequiredService<AppSettings>().GraphQl);

builder.Services.AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


var app = builder.Build();
app.UseCors();

var appSettings = builder.Configuration.Get<AppSettings>();
if (appSettings?.Swagger.Enabled == true)
{
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
}

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();