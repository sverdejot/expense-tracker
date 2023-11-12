using Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Persistance.Configuration.Expenses;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{

    public ExpenseConfiguration()
    {
    }

    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(expense => expense.Id);

        builder.Property(expense => expense.Id)
            .HasConversion(
                src => src.Value,
                raw => ExpenseId.Create(raw));

        builder.ComplexProperty(expense => expense.Amount);

        builder.Property(expense => expense.Description)
            .HasColumnName(nameof(Expense.Description))
            .HasConversion(
                src => src.Value,
                raw => ExpenseDescription.Create(raw));

        builder.HasIndex(expense => expense.Id);
    }
}

