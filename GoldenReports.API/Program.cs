using System.Text.Json.Serialization;
using GoldenReports.API.Configuration;
using GoldenReports.API.Extensions;
using GoldenReports.API.GraphQL;
using GoldenReports.API.OpenApi;
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
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
    .AddSwaggerGen();

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

builder.Services.AddGraphQL(builder => builder
        .AddSystemTextJson()
    // .AddErrorInfoProvider((opts, serviceProvider) =>
    // {
    //     var settings = serviceProvider.GetRequiredService<IOptions<GraphQLSettings>>();
    //     opts.ExposeExceptionDetails = settings.Value.ExposeExceptions;
    // })
    // .AddSchema<StarWarsSchema>()
    // .AddGraphTypes(typeof(StarWarsQuery).Assembly)
    // .UseMiddleware<CountFieldMiddleware>(false) // do not auto-install middleware
    // .UseMiddleware<InstrumentFieldsMiddleware>(false) // do not auto-install middleware
    // .ConfigureSchema((schema, serviceProvider) =>
    // {
    //     // install middleware only when the custom EnableMetrics option is set
    //     var settings = serviceProvider.GetRequiredService<IOptions<GraphQLSettings>>();
    //     if (settings.Value.EnableMetrics)
    //     {
    //         var middlewares = serviceProvider.GetRequiredService<IEnumerable<IFieldMiddleware>>();
    //         foreach (var middleware in middlewares)
    //             schema.FieldMiddleware.Use(middleware);
    //     }
    // })
);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddSingleton<GraphQLMiddleware>();

builder.Services
    .AddAuthentication(opts =>
    {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opts =>
        builder.Configuration.Bind($"{nameof(AppSettings.Security)}:{nameof(AppSettings.Security.Jwt)}", opts)
    );

builder.Services.AddAuthorization();

var app = builder.Build();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GraphQLMiddleware>();

if (appSettings?.GraphQl.EnableAltair == true)
{
    app.UseGraphQLAltair("/altair");
}

app.Run();