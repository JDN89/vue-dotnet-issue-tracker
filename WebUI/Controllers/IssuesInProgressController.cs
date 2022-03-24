using Application.DTOs;
using Application.Handlers.Issues.Commands;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssuesInProgressController: BaseController
{
     [HttpGet("{projectId}")]
        [Authorize]
        public async Task<ActionResult<List<GetIssueInProgressDto>>> GetAllIssues(Guid projectId)
        {
            return await Mediator.Send(new GetAllIssuesInProgress.Query{ProjId = projectId});
        }
        
         [HttpPut("{projectId}")]
            [Authorize]
            public async Task<IResult> UpdateAllIssuesInProgress([FromBody] List<GetIssueInProgressDto> inProgressIssues, Guid projectId)
            {
                
               await Mediator.Send(new DeleteIssuesInProgress.Command{ProjectId = projectId});
               if (inProgressIssues.Count<=0) return Results.Ok();
               await Mediator.Send(new AddIssuesInProgress.Command {Issues = inProgressIssues});
               
               return Results.Ok();
            }
}