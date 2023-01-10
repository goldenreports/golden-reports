using GoldenReports.Domain.Reports;

namespace GoldenReports.Application.DTOs.Reports;

public record ReportParameterDto
{
    public string Name { get; init; } = null!;
    
    public ScalarType Type { get; init; }
    
    public bool Required { get; init; }
    
    public string? DefaultValue { get; init; }
}