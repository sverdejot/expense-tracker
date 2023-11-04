using Domain.Shared.ValueObjects;

namespace Application.Expenses.Queries;

public record AmountDTO(Currency Currency, Decimal Quantity);