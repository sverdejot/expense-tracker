using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/status")]
[ApiController]
public sealed class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok();
    }
}
