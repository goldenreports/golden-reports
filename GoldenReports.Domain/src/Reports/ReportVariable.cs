using GoldenReports.Domain.Common;

namespace GoldenReports.Domain.Reports;

public class ReportVariable : Entity
{
    public Guid ReportId { get; set; }

    public ReportDefinition Report { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Expression { get; set; } = null!;
}