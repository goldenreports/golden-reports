using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Domain.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Commands;

public record CreateReport(CreateReportDto Report) : IRequest<ReportDto>;

public class CreateReportHandler : IRequestHandler<CreateReport, ReportDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IValidator<CreateReport> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateReportHandler(
        INamespaceRepository namespaceRepository,
        IValidator<CreateReport> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ReportDto> Handle(CreateReport request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(ReportDefinition), validationResult.Errors);
        }

        var parentNamespace =
            await this.namespaceRepository.GetNamespaceWithReports(request.Report.NamespaceId, cancellationToken);
        if (parentNamespace == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.Report.NamespaceId}");
        }

        var newReport = this.mapper.Map<ReportDefinition>(request.Report);
        parentNamespace.Reports.Add(newReport);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<ReportDto>(newReport);
    }
}
