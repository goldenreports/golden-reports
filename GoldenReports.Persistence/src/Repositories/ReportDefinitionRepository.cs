using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Reports;

namespace GoldenReports.Persistence.Repositories;

public class ReportDefinitionRepository : Repository<ReportDefinition>, IReportDefinitionRepository
{
    public ReportDefinitionRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
    }
}