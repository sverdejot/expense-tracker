using Application;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Create([FromRoute] Guid id, [FromBody]CreateUserRequest request)
    {
        var command = _mapper.Map<CreateUserCommand>((id, request));

        await _sender.Send(command);

        return Created($"api/users/{id}", string.Empty);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody]LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var token = await _sender.Send(command);

        return Ok(new { token =  token});
    }
}
