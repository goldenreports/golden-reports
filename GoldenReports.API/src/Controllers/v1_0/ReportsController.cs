using System.Net.Mime;
using GoldenReports.Application.DTOs.Assets;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Application.Features.Assets.Commands;
using GoldenReports.Application.Features.Assets.Queries;
using GoldenReports.Application.Features.Reports.Commands;
using GoldenReports.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenReports.API.Controllers.v1_0;

[Authorize]
[ApiController]
[Route("reports")]
[ApiVersion("1.0")]
public class ReportsController : ControllerBase
{
    private readonly IMediator mediator;

    public ReportsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet(Name = nameof(ReportsController.GetReports))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<ReportListItemDto>>> GetReports()
    {
        var reports = await this.mediator.Send(new GetReports());
        return this.Ok(reports);
    }

    [HttpGet("{reportId:guid}", Name = nameof(ReportsController.GetReportById))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<ReportDto>> GetReportById(Guid reportId)
    {
        var report = await this.mediator.Send(new GetReportById(reportId));
        return this.Ok(report);
    }

    [HttpPost(Name = nameof(ReportsController.CreateReport))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<ReportDto>> CreateReport([FromBody] CreateReportDto report)
    {
        var createdReport = await this.mediator.Send(new CreateReport(report));
        return this.CreatedAtAction(nameof(this.GetReportById), new {ReportId = createdReport.Id}, createdReport);
    }

    [HttpPut("{reportId:guid}", Name = nameof(ReportsController.UpdateReport))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<ReportDto>> UpdateReport(Guid reportId, [FromBody] UpdateReportDto report)
    {
        var updatedReport = await this.mediator.Send(new UpdateReport(reportId, report));
        return this.Ok(updatedReport);
    }

    [HttpDelete("{reportId:guid}", Name = nameof(ReportsController.DeleteReport))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteReport(Guid reportId)
    {
        await this.mediator.Send(new DeleteReport(reportId));
        return this.NoContent();
    }

    [HttpPost("{reportId:guid}/assets", Name = nameof(ReportsController.AddReportAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<AssetDto>>> AddReportAsset(Guid namespaceId,
        [FromBody] UpsertAssetDto asset)
    {
        var addedAsset = await this.mediator.Send(new AddReportAsset(namespaceId, asset));
        return this.CreatedAtAction(nameof(this.GetReportAsset), new {AssetId = addedAsset.Id}, addedAsset);
    }

    [HttpGet("assets/{assetId:guid}", Name = nameof(ReportsController.GetReportAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<AssetDto>> GetReportAsset(Guid assetId)
    {
        var asset = await this.mediator.Send(new GetReportAssetById(assetId));
        return this.Ok(asset);
    }

    [HttpPut("assets/{assetId:guid}", Name = nameof(ReportsController.UpdateReportAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<AssetDto>> UpdateReportAsset(Guid assetId, [FromBody] UpsertAssetDto asset)
    {
        var updatedAsset = await this.mediator.Send(new UpdateReportAsset(assetId, asset));
        return this.Ok(updatedAsset);
    }

    [HttpDelete("assets/{assetId:guid}", Name = nameof(ReportsController.DeleteReportAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteReportAsset(Guid assetId)
    {
        await this.mediator.Send(new DeleteReportAsset(assetId));
        return this.NoContent();
    }
}