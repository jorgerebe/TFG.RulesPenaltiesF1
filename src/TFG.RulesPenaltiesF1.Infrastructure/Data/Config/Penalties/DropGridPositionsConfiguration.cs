using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class DropGridPositionsConfiguration : IEntityTypeConfiguration<DropGridPositions>
{
   public void Configure(EntityTypeBuilder<DropGridPositions> builder)
   {
      builder.HasBaseType<Penalty>();
      builder.Property(r => r.Positions).IsRequired(false);
      builder.HasIndex(r => new { r.Positions, r.PenaltyTypeId})
            .IsUnique();
   }
}
