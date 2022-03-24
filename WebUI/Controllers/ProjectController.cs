using Application.DTOs;
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
    public async Task<ActionResult<List<GetProjectDto>>> Test()
    {
        return await Mediator.Send(new GetAllProjects.Query());
    }
}