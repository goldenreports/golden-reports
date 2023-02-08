using GoldenReports.Persistence.Abstractions;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenReports.Persistence.PostgreSQL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSQLPersistenceServices(this IServiceCollection services, IConfiguration configuration, string connectionStringName = "DefaultConnection")
    {
        services.AddDbContext<GoldenReportsDbContext>(opts => opts.UseNpgsql(
                configuration.GetConnectionString(connectionStringName), b => { b.EnableRetryOnFailure(3); })
            .UseSnakeCaseNamingConvention());

        services.AddPersistenceServices();
        services.AddSingleton<INameConverter, NameConverter>();
        return services;
    }
}
