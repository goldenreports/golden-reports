using System.Net.Mime;
using GoldenReports.API.Resources;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Features.DataContexts.Commands;
using GoldenReports.Application.Features.DataContexts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldenReports.API.Controllers.v1_0;

[Authorize]
[ApiController]
[Route("api/data-contexts")]
[ApiVersion("1.0")]
public class DataContextsController : ControllerBase
{
    private readonly IMediator mediator;

    public DataContextsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet(Name = nameof(DataContextsController.GetDataContexts))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<DataContextDto>>> GetDataContexts()
    {
        var dataContexts = await this.mediator.Send(new GetDataContexts());
        return this.Ok(dataContexts);
    }

    [HttpGet("{contextId:guid}", Name = nameof(DataContextsController.GetDataContextById))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataContextDto>> GetDataContextById(Guid contextId)
    {
        var dataContext = await this.mediator.Send(new GetDataContextById(contextId));
        return this.Ok(dataContext);
    }

    [HttpPost(Name = nameof(DataContextsController.CreateDataContext))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataContextDto>> CreateDataContext([FromBody] CreateDataContextDto context)
    {
        var createdContext = await this.mediator.Send(new CreateDataContext(context));
        return this.CreatedAtAction(nameof(this.GetDataContextById), new {ContextId = createdContext.Id}, createdContext);
    }

    [HttpPut("{contextId:guid}", Name = nameof(DataContextsController.UpdateDataContext))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataContextDto>> UpdateDataContext(Guid contextId,
        [FromBody] UpdateDataContextDto context)
    {
        var updatedContext = await this.mediator.Send(new UpdateDataContext(contextId, context));
        return this.Ok(updatedContext);
    }

    [HttpDelete("{contextId:guid}", Name = nameof(DataContextsController.DeleteDataContext))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteDataContext(Guid contextId)
    {
        await this.mediator.Send(new DeleteDataContext(contextId));
        return this.NoContent();
    }
}