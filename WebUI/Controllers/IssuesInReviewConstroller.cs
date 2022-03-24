using Application.DTOs;
using Application.Handlers.Issues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssuesInReviewController:BaseController
{
      [HttpGet("{projectId}")]
        [Authorize]
        public async Task<ActionResult<List<GetTestIssueDto>>> GetAllIssues(Guid projectId)
        {
            return await Mediator.Send(new GetAllTestIssues.Query{ProjId = projectId});
        }
        
}