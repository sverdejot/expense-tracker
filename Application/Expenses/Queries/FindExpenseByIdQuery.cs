using Application.Shared.Query;

namespace Application.Expenses.Queries;

public record FindExpenseByIdQuery(Guid Id) : IQuery<FindExpenseByIdResult>;