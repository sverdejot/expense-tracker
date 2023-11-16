using Application;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI;

[ApiController]
[Route("api/users")]
public class UsersController : ApiController
{
    public UsersController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var token = await _sender.Send(command);

        return Ok(token);
    }
}
