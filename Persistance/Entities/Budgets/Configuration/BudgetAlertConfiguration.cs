using Domain;
using Domain.Budgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance;

public class AlertConfiguration : IEntityTypeConfiguration<BudgetAlert>
{
    public void Configure(EntityTypeBuilder<BudgetAlert> builder)
    {
        var identityProperty = "BudgetAlertId";

        builder.Property<Guid>(identityProperty)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(identityProperty);
        builder.HasIndex(identityProperty);
    }
}
