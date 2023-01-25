using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Domain.Reports;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence.Repositories;

public class ReportDefinitionRepository : Repository<ReportDefinition>, IReportDefinitionRepository
{
    private readonly GoldenReportsDbContext dataContext;

    public ReportDefinitionRepository(GoldenReportsDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }
}