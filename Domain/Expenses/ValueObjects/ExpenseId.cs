﻿namespace Domain.Expenses;

public record class ExpenseId
{
    public Guid Value { get; private set; }

    protected ExpenseId(Guid value)
    {
        Value = value;
    }

    public static ExpenseId Create(Guid value) => new(value);

}

