using GoldenReports.Application.Constants;
using GoldenReports.Domain.Security;
using GoldenReports.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenReports.Persistence.Configuration.Security;

public class UserConfiguration : EntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ApplyEntityConfiguration();
        builder.HasAlternateKey(x => x.AuthContextKey).HasName("UK_User");
        builder.Property(x => x.AuthContextKey).HasMaxLength(StringSizes.Small);
        builder.Property(x => x.FirstName).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.LastName).HasMaxLength(StringSizes.ExtraSmall);
        builder.Property(x => x.Email).HasMaxLength(StringSizes.Small);
    }
}
