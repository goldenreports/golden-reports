using System.Net.Mime;
using GoldenReports.Application.DTOs.Assets;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Application.Features.Assets.Commands;
using GoldenReports.Application.Features.Assets.Queries;
using GoldenReports.Application.Features.DataContexts.Queries;
using GoldenReports.Application.Features.DataSources.Queries;
using GoldenReports.Application.Features.Namespaces.Commands;
using GoldenReports.Application.Features.Namespaces.Queries;
using GoldenReports.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenReports.API.Controllers.v1_0;

[Authorize]
[ApiController]
[Route("namespaces")]
[ApiVersion("1.0")]
public class NamespacesController : ControllerBase
{
    private readonly IMediator mediator;

    public NamespacesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("root", Name = nameof(NamespacesController.GetRootNamespace))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<NamespaceDto>> GetRootNamespace()
    {
        var rootNamespace = await this.mediator.Send(new GetRootNamespace());
        return this.Ok(rootNamespace);
    }
    
    [HttpGet("{namespaceId:guid}", Name = nameof(NamespacesController.GetNamespace))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<NamespaceDto>> GetNamespace(Guid namespaceId)
    {
        var foundNamespace = await this.mediator.Send(new GetNamespaceById(namespaceId));
        return this.Ok(foundNamespace);
    }

    [HttpGet("{namespaceId:guid}/ancestors", Name = nameof(NamespacesController.GetAncestors))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<NamespaceDto>>> GetAncestors(Guid namespaceId)
    {
        var foundNamespace = await this.mediator.Send(new GetNamespaceAncestors(namespaceId));
        return this.Ok(foundNamespace);
    }

    [HttpGet("{namespaceId:guid}/namespaces", Name = nameof(NamespacesController.GetInnerNamespaces))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<NamespaceDto>>> GetInnerNamespaces(Guid namespaceId)
    {
        var rootNamespaces = await this.mediator.Send(new GetInnerNamespaces(namespaceId));
        return this.Ok(rootNamespaces);
    }

    [HttpGet("{namespaceId:guid}/data-sources", Name = nameof(NamespacesController.GetNamespaceDataSources))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<DataSourceDto>>> GetNamespaceDataSources(Guid namespaceId)
    {
        var dataSources = await this.mediator.Send(new GetDataSourcesByNamespaceId(namespaceId));
        return this.Ok(dataSources);
    }

    [HttpGet("{namespaceId:guid}/data-contexts", Name = nameof(NamespacesController.GetNamespaceDataContexts))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<DataContextDto>>> GetNamespaceDataContexts(Guid namespaceId)
    {
        var dataContexts = await this.mediator.Send(new GetDataContextsByNamespaceId(namespaceId));
        return this.Ok(dataContexts);
    }

    [HttpGet("{namespaceId:guid}/assets", Name = nameof(NamespacesController.GetNamespaceAssets))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<AssetDto>>> GetNamespaceAssets(Guid namespaceId)
    {
        var assets = await this.mediator.Send(new GetNamespaceAssetsByNamespaceId(namespaceId));
        return this.Ok(assets);
    }

    [HttpGet("{namespaceId:guid}/reports", Name = nameof(NamespacesController.GetNamespaceReports))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<ReportListItemDto>>> GetNamespaceReports(Guid namespaceId)
    {
        var reports = await this.mediator.Send(new GetReportsByNamespaceId(namespaceId));
        return this.Ok(reports);
    }
    
    [HttpPost(Name = nameof(NamespacesController.CreateNamespace))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<NamespaceDto>> CreateNamespace([FromBody]CreateNamespaceDto newNamespace)
    {
        var createdNamespace = await this.mediator.Send(new CreateNamespace(newNamespace));
        return this.Ok(createdNamespace);
    }
    
    [HttpPut("{namespaceId:guid}", Name = nameof(NamespacesController.UpdateNamespace))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<NamespaceDto>> UpdateNamespace(Guid namespaceId, [FromBody]UpdateNamespaceDto modifiedNamespace)
    {
        var updatedNamespace = await this.mediator.Send(new UpdateNamespace(namespaceId, modifiedNamespace));
        return this.Ok(updatedNamespace);
    }
    
    [HttpDelete("{namespaceId:guid}", Name = nameof(NamespacesController.DeleteNamespace))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteNamespace(Guid namespaceId)
    {
        await this.mediator.Send(new DeleteNamespace(namespaceId));
        return this.NoContent();
    }
    
    [HttpPost("{namespaceId:guid}/assets", Name = nameof(NamespacesController.AddNamespaceAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<IEnumerable<AssetDto>>> AddNamespaceAsset(Guid namespaceId, [FromBody]UpsertAssetDto asset)
    {
        var addedAsset = await this.mediator.Send(new AddNamespaceAsset(namespaceId, asset));
        return this.CreatedAtAction(nameof(this.GetNamespaceAsset), new { AssetId = addedAsset.Id }, addedAsset);
    }
    
    [HttpGet("assets/{assetId:guid}", Name = nameof(NamespacesController.GetNamespaceAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<AssetDto>> GetNamespaceAsset(Guid assetId)
    {
        var asset = await this.mediator.Send(new GetNamespaceAssetById(assetId));
        return this.Ok(asset);
    }
    
    [HttpPut("assets/{assetId:guid}", Name = nameof(NamespacesController.UpdateNamespaceAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult<AssetDto>> UpdateNamespaceAsset(Guid assetId, [FromBody]UpsertAssetDto asset)
    {
        var updatedAsset = await this.mediator.Send(new UpdateNamespaceAsset(assetId, asset));
        return this.Ok(updatedAsset);
    }
    
    [HttpDelete("assets/{assetId:guid}", Name = nameof(NamespacesController.DeleteNamespaceAsset))]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType(typeof(ErrorDto))]
    public async Task<ActionResult> DeleteNamespaceAsset(Guid assetId)
    {
        await this.mediator.Send(new DeleteNamespaceAsset(assetId));
        return this.NoContent();
    }
}