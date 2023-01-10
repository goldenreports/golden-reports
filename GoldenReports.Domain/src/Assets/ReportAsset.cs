using GoldenReports.Domain.Reports;

namespace GoldenReports.Domain.Assets;

public class ReportAsset : Asset
{
    public Guid ReportId { get; set; }

    public ReportDefinition Report { get; set; } = null!;
}