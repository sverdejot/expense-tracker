using Application.Budgets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Controllers.Budgets;

[ApiController]
[Route("budgets")]
public class BudgetsController : ApiController
{
    public BudgetsController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpGet]
    public async Task<ActionResult> FindAllBudgets()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindBudget([FromRoute]Guid id)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> CreateBudget([FromRoute]Guid id, [FromBody]CreateBudgetRequest request)
    {
        // TODO: implement reques aswell as mappings
        var command = _mapper.Map<CreateBudgetCommand>((id, request));

        await _sender.Send(command);

        return Created($"api/budgets/{id}", string.Empty);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteBudget([FromRoute]Guid id)
    {
        var command = new DeleteBudgetCommand(id);

        await _sender.Send(command);

        return NoContent();
    }
}
