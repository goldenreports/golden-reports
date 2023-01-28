using System.Net.Mime;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;
using GoldenReports.Application.Features.DataSources.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenReports.API.Controllers.v1_0;

[Authorize]
[ApiController]
[Route("data-sources")]
[ApiVersion("1.0")]
public class DataSourcesController : ControllerBase
{
    private readonly IMediator mediator;

    public DataSourcesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet(Name = nameof(DataSourcesController.GetDataSources))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<DataSourceDto>>> GetDataSources()
    {
        var dataSources = await this.mediator.Send(new GetDataSources());
        return this.Ok(dataSources);
    }

    [HttpGet("{dataSourceId:guid}", Name = nameof(DataSourcesController.GetDataSourceById))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataSourceDto>> GetDataSourceById(Guid dataSourceId)
    {
        var dataSource = await this.mediator.Send(new GetDataSourceById(dataSourceId));
        return this.Ok(dataSource);
    }

    [HttpPost(Name = nameof(DataSourcesController.CreateDataSource))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataSourceDto>> CreateDataSource([FromBody] CreateDataSourceDto dataSource)
    {
        var createdDataSource = await this.mediator.Send(new CreateDataSource(dataSource));
        return this.CreatedAtAction(nameof(this.GetDataSourceById), new {DataSourceId = createdDataSource.Id},
            createdDataSource);
    }

    [HttpPut("{dataSourceId:guid}", Name = nameof(DataSourcesController.UpdateDataSource))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<DataSourceDto>> UpdateDataSource(Guid dataSourceId,
        [FromBody] UpdateDataSourceDto dataSource)
    {
        var updatedDataSource = await this.mediator.Send(new UpdateDataSource(dataSourceId, dataSource));
        return this.Ok(updatedDataSource);
    }

    [HttpDelete("{dataSourceId:guid}", Name = nameof(DataSourcesController.DeleteDataSource))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteDataSource(Guid dataSourceId)
    {
        await this.mediator.Send(new DeleteDataSource(dataSourceId));
        return this.NoContent();
    }
}