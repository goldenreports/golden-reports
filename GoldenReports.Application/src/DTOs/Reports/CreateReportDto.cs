namespace GoldenReports.Application.DTOs.Reports;

public record CreateReportDto
{
    public Guid NamespaceId { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string? Description { get; init; }
    
    public string? Query { get; init; }
    
    public string? Styles { get; init; }
    
    public string? Template { get; init; }

    public IEnumerable<ReportParameterDto> Parameters { get; init; } = new List<ReportParameterDto>();

    public IEnumerable<ReportVariableDto> Variables { get; init; } = new List<ReportVariableDto>();
}