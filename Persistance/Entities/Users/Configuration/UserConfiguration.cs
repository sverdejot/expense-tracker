using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Id)
            .HasConversion(
                src => src.Value,
                raw => UserId.Create(raw));
        builder.HasIndex(user => user.Id);
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Mail)
            .HasConversion(
                src => src.Value,
                raw => UserMail.Create(raw));

        builder.HasIndex(user => user.Mail);
    }
}
