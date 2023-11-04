using Domain.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Persistance.Budgets;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(budget => budget.Id);

        builder.Property(budget => budget.Id)
            .HasConversion(
                src => src.Value,
                raw => new BudgetId(raw));

        // TODO: Complex types (available soon)
        builder.Property(budget => budget.MaximumAmount)
            .HasConversion(
                src => JsonConvert.SerializeObject(src, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }),
                raw => JsonConvert.DeserializeObject<BudgetAmount>(raw, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!);

        // TODO: Complex types (available soon)
        builder.Property(budget => budget.Period)
            .HasConversion(
                src => JsonConvert.SerializeObject(src, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }),
                raw => JsonConvert.DeserializeObject<BudgetPeriod>(raw, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!);
    }
}

