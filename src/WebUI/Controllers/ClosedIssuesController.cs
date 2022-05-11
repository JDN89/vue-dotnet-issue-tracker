using Application.DTOs.Issues;
using Application.Handlers.Issues.Commands;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClosedIssuesController : BaseController
{
    [HttpGet("{projectId}")]
    [Authorize]
    public async Task<ActionResult<List<GetClosedIssueDto>>> GetAllIssues(Guid projectId)
    {
        return await Mediator.Send(new GetAllClosedIssuesQuery { ProjId = projectId });
    }
    [HttpPut("{projectId}")]
    [Authorize]
    public async Task<IResult> UpdateAllClosedIssues([FromBody] List<GetClosedIssueDto> closedIssues, Guid projectId)
    {
        await Mediator.Send(new DeleteClosedIssues.Command { ProjectId = projectId });
        if (closedIssues.Count <= 0) return Results.Ok();
        await Mediator.Send(new AddClosedIssues.Command { Issues = closedIssues });

        return Results.Ok();
    }

    [HttpPut]
    [Route("UpdateSingleClosedIssue")]
    [Authorize]
    public async Task<IActionResult> UpdateSingleClosedIssue(UpdateIssueDto openIssue)
    {
        await Mediator.Send(new UpdateSingleClosedIssue.Command { Issue = openIssue });

        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteOpenIssue(Guid id)
    {
        await Mediator.Send(new DeleteIssueInProgress.Command
        {
            Id = id
        });
        return NoContent();
    }
}
