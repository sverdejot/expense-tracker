using Domain;
using Domain.Budget;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class DateAlertConfiguration : IEntityTypeConfiguration<DateAlert>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DateAlert> builder)
    {
        builder.HasBaseType<BudgetAlert>();

        builder.Property(alert => alert.AlertingDate)
            .IsRequired();
    }
}
