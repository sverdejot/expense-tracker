using Domain;
using Domain.Budgets;
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
                raw => BudgetId.Create(raw));
        
        builder.Property(budget => budget.Owner)
            .HasConversion(
                src => src.Value,
                raw => UserId.Create(raw));

        builder.ComplexProperty(budget => budget.MaximumAmount);

        builder.ComplexProperty(budget => budget.Period);

        // Configured no navigation to parent entity since its the aggregate
        // The info will be populated on each retrieve
        builder.HasMany(budget => budget.Records)
            .WithMany();

        builder.HasMany(budget => budget.Alerts)
            .WithMany();
    }
}

