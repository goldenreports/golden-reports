using GoldenReports.Domain.Common;

namespace GoldenReports.Domain.Reports;

public class ReportParameter : Entity
{
    public Guid ReportId { get; set; }

    public ReportDefinition Report { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public ScalarType Type { get; set; } = ScalarType.Text;

    public bool Required { get; set; }
    
    public string? DefaultValue { get; set; }
}