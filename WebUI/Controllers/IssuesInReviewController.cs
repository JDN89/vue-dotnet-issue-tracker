using Application.DTOs.Issues;
using Application.Handlers.Issues.Commands;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssuesInReviewController : BaseController
{
    [HttpGet("{projectId}")]
    [Authorize]
    public async Task<ActionResult<List<GetIssueInReviewDto>>> GetAllIssues(Guid projectId)
    {
        return await Mediator.Send(new GetAllTestIssues.Query { ProjId = projectId });
    }

    [HttpPut("{projectId}")]
    [Authorize]
    public async Task<IResult> UpdateAllIssuesInReview([FromBody] List<GetIssueInReviewDto> InReviewIssues, Guid projectId)
    {
        await Mediator.Send(new DeleteIssuesInReview.Command { ProjectId = projectId });
        if (InReviewIssues.Count <= 0) return Results.Ok();
        await Mediator.Send(new AddIssuesInReview.Command { Issues = InReviewIssues });

        return Results.Ok();
    }


    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IResult> DeleteIssueInReview(Guid id)
    {
        await Mediator.Send(new DeleteIssueInReview.Command
        {
            Id = id
        });
        return Results.Ok();

    }
}
