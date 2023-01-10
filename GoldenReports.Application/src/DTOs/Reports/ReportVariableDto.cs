namespace GoldenReports.Application.DTOs.Reports;

public record ReportVariableDto
{
    public string Name { get; init; } = null!;

    public string Expression { get; init; } = null!;
}