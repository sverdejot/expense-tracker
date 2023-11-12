using System;
using Application.Shared.Query;
using Domain.Expenses;
using MapsterMapper;

namespace Application.Expenses.Queries;

public class FindExpenseByIdQueryHandler : IQueryHandler<FindExpenseByIdQuery, FindExpenseByIdResult>
{
    private readonly IExpenseRepository _expenseRepository;

    private readonly IMapper _mapper;

    public FindExpenseByIdQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _mapper = mapper;
    }

    public async Task<FindExpenseByIdResult> Handle(FindExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var id = ExpenseId.Create(request.Id);
        var criteria = new FindExpenseByIdCriteria(id);

        var expense = await _expenseRepository.MatchFirstOrDefault(criteria);

        return new FindExpenseByIdResult(_mapper.Map<ExpenseDTO>(expense));
    }
}

