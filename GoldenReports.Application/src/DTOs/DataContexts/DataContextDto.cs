using GoldenReports.Application.DTOs.Common;

namespace GoldenReports.Application.DTOs.DataContexts;

public record DataContextDto : EntityDto
{
    public Guid NamespaceId { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string Schema { get; init; } = null!;
}