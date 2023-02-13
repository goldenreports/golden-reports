using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Commands;

public record UpdateReport(Guid ReportId, UpdateReportDto Report) : IRequest<ReportDto>;

public class UpdateReportHandler : IRequestHandler<UpdateReport, ReportDto>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IValidator<UpdateReport> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateReportHandler(
        IReportDefinitionRepository reportDefinitionRepository,
        IValidator<UpdateReport> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ReportDto> Handle(UpdateReport request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(ReportDefinition), validationResult.Errors);
        }

        var report = await this.reportDefinitionRepository.Get(request.ReportId, cancellationToken);
        if (report == null)
        {
            throw new NotFoundException(nameof(ReportDefinition), $"Id = {request.ReportId}");
        }

        this.mapper.Map(request.Report, report);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<ReportDto>(report);
    }
}
