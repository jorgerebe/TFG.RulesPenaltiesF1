using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class DriveThroughConfiguration : IEntityTypeConfiguration<DriveThrough>
{
   public void Configure(EntityTypeBuilder<DriveThrough> builder)
   {
      builder.HasBaseType<Penalty>();
      builder.Property(r => r.ElapsedSeconds).IsRequired();
      builder.HasIndex(r => new { r.ElapsedSeconds, r.PenaltyTypeId })
            .IsUnique();
   }
}
