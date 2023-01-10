using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Queries;

public record GetDataContextById(Guid ContextId): IRequest<DataContextDto>;

internal class GetDataContextByIdHandler : IRequestHandler<GetDataContextById, DataContextDto>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IMapper mapper;

    public GetDataContextByIdHandler(IDataContextRepository dataContextRepository, IMapper mapper)
    {
        this.dataContextRepository = dataContextRepository;
        this.mapper = mapper;
    }
    
    public async Task<DataContextDto> Handle(GetDataContextById request, CancellationToken cancellationToken)
    {
        var context = await this.dataContextRepository.Get(request.ContextId, cancellationToken);
        if (context == null)
        {
            throw new NotFoundException(nameof(DataContext), $"Id = {request.ContextId}");
        }

        return this.mapper.Map<DataContextDto>(context);
    }
}