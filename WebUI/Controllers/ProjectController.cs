using Application.DTOs;
using Application.Handlers.Projects.Commands;
using Application.Handlers.Projects.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : BaseController
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<GetProjectDto>>> GetProjects()
    {
        return await Mediator.Send(new GetAllProjects.Query());
    }

    [HttpPost("{projectTitle}")]
    [Authorize]
    public async Task<IResult> AddProject(string projectTitle)
    {
        await Mediator.Send(new AddNewProject.Command {Title = projectTitle});
        return Results.Ok();
    }
}