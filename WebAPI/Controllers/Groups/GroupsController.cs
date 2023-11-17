using Application.Groups;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Groups;

[Route("api/groups")]
[ApiController]

public class GroupsController : ApiController
{
    public GroupsController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> CreateGroup([FromRoute]Guid id, [FromBody]CreateGroupRequest request)
    {
        var command = _mapper.Map<CreateGroupCommand>((id, request));

        await _sender.Send(command);

        return Created($"api/groups/{id}", string.Empty);
    }
}
