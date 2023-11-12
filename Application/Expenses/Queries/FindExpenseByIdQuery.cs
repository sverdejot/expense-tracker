using Application.Shared.Query;

namespace Application.Expenses.Queries;

public sealed record FindExpenseByIdQuery(Guid Id) : IQuery<FindExpenseByIdResult>;