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

        // Until ComplexTypes (available soon), JSON is enough
        builder.Property(expense => expense.Amount)
            .HasColumnName(nameof(Expense.Amount))
            .HasConversion(
                src => JsonConvert.SerializeObject(src, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }),
                raw => JsonConvert.DeserializeObject<ExpenseAmount>(raw, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!);

        builder.Property(expense => expense.Description)
            .HasColumnName(nameof(Expense.Description))
            .HasConversion(
                src => src.Value,
                raw => ExpenseDescription.Create(raw));

        builder.HasIndex(expense => expense.Id);
    }
}

