using GN2.Business.Core.Abstracts.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineVerse.Domain;

public class CineUser : GN2.AppSign.Library.Entities.ApplicationUser
{
    public CineUser()
    {
    }
}

public class CineUserConfiguration : IEntityTypeConfiguration<CineUser>
{
    public void Configure(EntityTypeBuilder<CineUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.OwnsOne(x => x.Condition, y =>
        {
            y.Property(b => b.CreatedBy).IsRequired();
            y.Property(b => b.IsEnabled).HasDefaultValue(true);
            y.Property(b => b.Status).HasDefaultValue(ConditionStatus.Active).HasSentinel(ConditionStatus.Active);
            y.Property(b => b.RegistDate).HasDefaultValueSql("getutcdate()");
            y.Property(b => b.LastUpdate).HasDefaultValueSql("getutcdate()");
            y.Property(b => b.DeletedDate).HasDefaultValueSql("getutcdate()");
        });
    }
}