using GoldenReports.Application.DTOs.Common;

namespace GoldenReports.Application.DTOs.Namespaces;

public record NamespaceDto : EntityDto
{
    public Guid? ParentId { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string? Description { get; init; }
}