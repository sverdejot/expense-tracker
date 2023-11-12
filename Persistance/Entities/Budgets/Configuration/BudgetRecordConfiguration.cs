using Domain.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance;

public class BudgetRecordConfiguration : IEntityTypeConfiguration<BudgetRecord>
{
    public void Configure(EntityTypeBuilder<BudgetRecord> builder)
    {
        var identityProperty = "BudgetRecordId";

        builder.Property<Guid>(identityProperty)
            .ValueGeneratedOnAdd()
            .IsRequired();
            
        builder.HasKey(identityProperty);
        builder.HasIndex(identityProperty);
    }
}
