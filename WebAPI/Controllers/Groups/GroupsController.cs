using Application;
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
    [HttpGet]
    public async Task<ActionResult> GetGroups()
    {
        var query = new FindAllGroupsQuery();

        var response = await _sender.Send(query);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> CreateGroup([FromRoute]Guid id, [FromBody]CreateGroupRequest request)
    {
        var command = _mapper.Map<CreateGroupCommand>((id, request));

        await _sender.Send(command);

        return Created($"api/groups/{id}", string.Empty);
    }

    [HttpPut("{id:guid}/join")]
    public async Task<ActionResult> JoinGroup([FromRoute] Guid id, [FromBody] JoinGroupRequest request)
    {
        var command = _mapper.Map<JoinGroupCommand>((id, request));

        await _sender.Send(command);

        return Ok();
    }
    
    [HttpPut("{id:guid}/records/{recordId:guid}")]
    public async Task<ActionResult> CreateRecord([FromRoute] Guid id, [FromRoute] Guid recordId, [FromBody] CreateRecordRequest request)
    {
        var command = _mapper.Map<CreateRecordCommand>((id, recordId, request));

        await _sender.Send(command);

        return Created($"api/groups/{id}/record/{recordId}", string.Empty);
    }
}
