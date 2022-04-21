using System.Reflection.Metadata;
using Application.DTOs;
using Application.DTOs.Issues;
using Application.Handlers.Issues.Commands;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenIssuesController : BaseController
{
    [HttpGet("{projectId}")]
    [Authorize]
    public async Task<ActionResult<List<GetOpenIssueDto>>> GetAllIssues(Guid projectId)
    {
        return await Mediator.Send(new GetAllOpenIssues.Query {ProjId = projectId});
    }

    [HttpPut("{projectId}")]
    [Authorize]
    public async Task<IResult> UpdateAllOpenIssues([FromBody] List<GetOpenIssueDto> openIssues, Guid projectId)
    {
        await Mediator.Send(new DeleteAllOpenIssuesInProject.Command {ProjectId = projectId});
        if (openIssues.Count <= 0) return Results.Ok();
        await Mediator.Send(new AddOpenIssues.Command {Issues = openIssues});

        return Results.Ok();
    }
    [HttpPut]
    [Route("UpdateSingleOpenIssue")]
    [Authorize]
    public async Task<IResult> UpdateSingleOpenIssue( UpdateIssueDto openIssue)
    {
        await Mediator.Send(new UpdateSingleOpenIssue.Command {Issue = openIssue});

        return Results.Ok();
    }
}