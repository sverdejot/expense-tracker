using Domain;
using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(group => group.Id);
        builder.HasIndex(group => group.Id);
        builder.Property(group => group.Id)
            .HasConversion(
                src => src.Value,
                raw => GroupId.Create(raw))
            .ValueGeneratedNever();

        builder.Property(group => group.Admin)
            .HasConversion(
                src => src.Value,
                raw => MemberId.Create(raw));
        
        builder.Property(group => group.Name)
            .HasMaxLength(50)
            .HasConversion(
                src => src.Value,
                raw => GroupName.Create(raw));

        builder.OwnsMany(group => group.Members,
            membersBuilder => {
                membersBuilder.WithOwner().HasForeignKey("GroupId");
                membersBuilder.HasKey(member => member.Value);
                membersBuilder.Property(member => member.Value)
                    .ValueGeneratedNever();
            });
            

        builder.OwnsMany(group => group.Records,
            recordBuilder => {
                var identityProperty = "GroupRecordId";
                recordBuilder.Property<Guid>(identityProperty)
                    .ValueGeneratedOnAdd();

                recordBuilder.HasKey(identityProperty);

                
                recordBuilder.Property(record => record.Creator)
                    .HasConversion(
                        src => src.Value,
                        raw => UserId.Create(raw));
                
                recordBuilder.Property(record => record.Amount);

                recordBuilder.OwnsMany(record => record.Percentages,
                    percentagesBuilder => {
                        var percentageIdentityProperty = "MemberPercentageId";
                        percentagesBuilder.Property<Guid>(percentageIdentityProperty)
                            .ValueGeneratedOnAdd();
                        percentagesBuilder.HasKey(percentageIdentityProperty);


                        percentagesBuilder.Property(percentage => percentage.Member)
                            .HasConversion(
                                src => src.Value,
                                raw => UserId.Create(raw));
                        
                        percentagesBuilder.Property(percentage => percentage.Percentage);
                    });
            });
    }
}
