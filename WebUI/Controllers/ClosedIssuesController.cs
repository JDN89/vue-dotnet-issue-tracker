using Application.DTOs;
using Application.Handlers.Issues.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClosedIssuesController:BaseController
{
     [HttpGet("{projectId}")]
        [Authorize]
        public async Task<ActionResult<List<GetClosedIssueDto>>> GetAllIssues(Guid projectId)
        {
            return await Mediator.Send(new GetAllClosedIssues.Query{ProjId = projectId});
        }
}