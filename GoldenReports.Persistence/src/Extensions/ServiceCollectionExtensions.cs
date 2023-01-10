using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenReports.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration, string connectionStringName = "DefaultConnection")
    {
        services.AddDbContext<GoldenReportsDbContext>(opts => opts.UseNpgsql(
                configuration.GetConnectionString(connectionStringName), b => { b.EnableRetryOnFailure(3); })
            .UseSnakeCaseNamingConvention());

        services.AddScoped<INamespaceRepository, NamespaceRepository>();
        services.AddScoped<IDataSourceRepository, DataSourceRepository>();
        services.AddScoped<IDataContextRepository, DataContextRepository>();
        services.AddScoped<INamespaceAssetRepository, NamespaceAssetRepository>();
        services.AddScoped<IReportDefinitionRepository, ReportDefinitionRepository>();
        services.AddScoped<IReportAssetRepository, ReportAssetRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}