using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Assets;

namespace GoldenReports.Persistence.Repositories;

public class ReportAssetRepository : Repository<ReportAsset>, IReportAssetRepository
{
    public ReportAssetRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
    }
}