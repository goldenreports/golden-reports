using GoldenReports.Application.DTOs.Common;

namespace GoldenReports.Application.DTOs.Reports;

public record ReportListItemDto : EntityDto
{
    public Guid NamespaceId { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string? Description { get; init; }
}