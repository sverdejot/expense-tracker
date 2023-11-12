using Domain;
using Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class DateAlertConfiguration : IEntityTypeConfiguration<DateBudgetAlert>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DateBudgetAlert> builder)
    {
        builder.HasBaseType<BudgetAlert>();

        builder.Property(alert => alert.AlertingDate)
            .IsRequired();
    }
}
