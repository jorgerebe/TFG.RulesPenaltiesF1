using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class StopAndGoConfiguration : IEntityTypeConfiguration<StopAndGo>
{
   public void Configure(EntityTypeBuilder<StopAndGo> builder)
   {
      builder.HasBaseType<DriveThrough>();
      builder.Property(r => r.ElapsedSeconds).IsRequired();
      builder.Property(r => r.Seconds).IsRequired();

      builder.HasIndex(r => new { r.ElapsedSeconds, r.Seconds, r.PenaltyTypeId })
            .IsUnique();
   }
}
