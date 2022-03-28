using Application.DTOs;
using Application.Handlers.Projects.Commands;
using Application.Handlers.Projects.Queries;
using Domain.Entities;
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddProject([FromBody] GetProjectDto newProject)
    {
        return HandleResult(

            await Mediator.Send(new AddNewProject.Command {NewProject = newProject})
        );

    }
}