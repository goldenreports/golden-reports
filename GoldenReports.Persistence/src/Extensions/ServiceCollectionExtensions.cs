using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Persistence.Configuration;
using GoldenReports.Persistence.Middlewares;
using GoldenReports.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoldenReports.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        typeof(EntityTypeConfiguration).Assembly.DefinedTypes
            .Where(x => x is { IsAbstract: false, IsGenericTypeDefinition: false } &&
                        typeof(EntityTypeConfiguration).IsAssignableFrom(x))
            .ToList()
            .ForEach(x => services.AddSingleton(typeof(EntityTypeConfiguration), x));

        services.AddScoped<IDbContextMiddleware, AuditMiddleware>();

        services.AddScoped<INamespaceRepository, NamespaceRepository>();
        services.AddScoped<IDataSourceRepository, DataSourceRepository>();
        services.AddScoped<IDataContextRepository, DataContextRepository>();
        services.AddScoped<INamespaceAssetRepository, NamespaceAssetRepository>();
        services.AddScoped<IReportDefinitionRepository, ReportDefinitionRepository>();
        services.AddScoped<IReportAssetRepository, ReportAssetRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
