using Application.Expenses.Queries;
using Application.Expenses.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Expenses;

[Route("api/expenses")]
[ApiController]
public class ExpensesController : ApiController
{
	public ExpensesController(ISender sender, IMapper mapper) : base(sender, mapper)
	{
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<FindExpenseResponse>> FindExpense([FromRoute]Guid id)
	{
		var query = _mapper.Map<FindExpenseByIdQuery>(id);

		var response = await _sender.Send(query);

		return Ok(_mapper.Map<FindExpenseResponse>(response));
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> CreateExpense([FromRoute]Guid id, [FromBody]CreateExpenseRequest request)
	{
		var command = _mapper.Map<CreateExpenseCommand>((id, request));

		await _sender.Send(command);

		return Created($"api/expense/{id}", string.Empty);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteExpense([FromRoute]Guid id)
	{
		var command = _mapper.Map<DeleteExpenseCommand>(id);

		await _sender.Send(command);

		return NoContent();
	}
}

