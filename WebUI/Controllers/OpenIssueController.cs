using Application.DTOs.Issues;
using Application.Handlers.Issues.Commands;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenIssuesController : BaseController
{
    [HttpGet("{projectId}")]
    [Authorize]
    public async Task<ActionResult<List<GetOpenIssueDto>>> GetAllIssues(Guid projectId)
    {
        return await Mediator.Send(new GetAllOpenIssues.Query { ProjId = projectId });
    }



    [HttpPut("{projectId}")]
    [Authorize]
    public async Task<IActionResult> UpdateAllOpenIssues([FromBody] List<GetOpenIssueDto> openIssues, Guid projectId)
    {
        await Mediator.Send(new DeleteAllOpenIssuesInProject.Command { ProjectId = projectId });
        if (openIssues.Count <= 0) return NoContent();
        await Mediator.Send(new AddOpenIssues.Command { Issues = openIssues });

        return NoContent();
    }
    [HttpPut]
    [Route("UpdateSingleOpenIssue")]
    [Authorize]
    public async Task<IActionResult> UpdateSingleOpenIssue(UpdateIssueDto openIssue)
    {
        await Mediator.Send(new UpdateSingleOpenIssue.Command { Issue = openIssue });

        return NoContent();
    }
    [HttpPost]
    [Authorize]
    public async Task<IResult> AddNewIssue(AddNewIssueDto newIssue)
    {

        var issue = await Mediator.Send(new AddNewIssue.Command { Issue = newIssue });
        if (issue is not null)
            return Results.Ok(issue);
        else
        {
            throw new Exception("no issue returned from db");
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IResult> DeleteOpenIssue(Guid id)
    {
        await Mediator.Send(new DeleteOpenIssue.Command
        {
            Id = id
        });
        return Results.Ok();

    }
}
