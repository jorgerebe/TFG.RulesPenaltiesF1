using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class ReprimandConfiguration : IEntityTypeConfiguration<Reprimand>
{
   public void Configure(EntityTypeBuilder<Reprimand> builder)
   {
      builder.HasBaseType<Penalty>();
      builder.Property(r => r.DrivingReprimand).IsRequired(false);
      builder.HasIndex(r => new { r.DrivingReprimand, r.PenaltyTypeId })
            .IsUnique();
   }
}
