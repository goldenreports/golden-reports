using GoldenReports.Application.DTOs.Common;

namespace GoldenReports.Application.DTOs.DataSources;

public record DataSourceDto : EntityDto
{
    public Guid NamespaceId { get; init; }
    
    public string Code { get; init; } = null!;

    public string Name { get; init; } = null!;
    
    public string? Description { get; init; }

    public string ConnectionString { get; init; } = null!;
}