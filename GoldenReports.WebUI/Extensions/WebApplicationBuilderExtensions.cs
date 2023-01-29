using System.Text.Json.Serialization;
using GoldenReports.API.Extensions;
using GoldenReports.Application.Abstractions.Security;
using GoldenReports.Application.Extensions;
using GoldenReports.Persistence.Extensions;
using GoldenReports.WebUI.Configuration;
using GoldenReports.WebUI.OpenApi;
using GoldenReports.WebUI.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GoldenReports.WebUI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddAppConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<AppSettings>(builder.Configuration)
            .AddScoped<AppSettings>(x => x.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value)
            .AddScoped<SwaggerSettings>(x => x.GetRequiredService<AppSettings>().Swagger)
            .AddScoped<SecuritySettings>(x => x.GetRequiredService<AppSettings>().Security)
            .AddScoped<ClientSettings>(x => x.GetRequiredService<AppSettings>().Client);
        return builder;
    }
    
    public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder, string prefix)
    {
        builder.Services
            .AddControllersWithViews(x => x.UseGeneralRoutePrefix(prefix))
            .AddGoldenReportsControllers()
            .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        return builder;
    }

    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
            .AddSwaggerGen();
        return builder;
    }

    public static WebApplicationBuilder AddVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        });
        builder.Services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                // options.SubstituteApiVersionInUrl = true;
            });

        return builder;
    }

    public static WebApplicationBuilder AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opts =>
                builder.Configuration.Bind($"{nameof(AppSettings.Security)}:{nameof(SecuritySettings.Jwt)}", opts)
            );
        builder.Services.AddAuthorization();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IAuthContext, AuthContext>();
        
        return builder;
    }
    
    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(opts =>
        {
            opts.AddDefaultPolicy(policy =>
            {
                var corsSettings = builder.Configuration
                    .GetSection($"{nameof(AppSettings.Security)}:{nameof(SecuritySettings.Cors)}")
                    .Get<CorsSettings>();
        
                policy.WithOrigins(corsSettings?.AllowedOrigins ?? Array.Empty<string>())
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return builder;
    }

    public static WebApplicationBuilder AddGoldenReports(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);
        return builder;
    }
}