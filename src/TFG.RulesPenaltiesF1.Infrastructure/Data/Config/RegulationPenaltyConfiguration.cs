using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class RegulationPenaltyConfiguration : IEntityTypeConfiguration<RegulationPenalty>
{
   public void Configure(EntityTypeBuilder<RegulationPenalty> builder)
   {
      builder.HasKey(key => new { key.RegulationId, key.PenaltyId });

      builder
         .HasOne(r => r.Regulation)
         .WithMany(r => r.Penalties)
         .HasForeignKey(r => r.RegulationId);

      builder
         .HasOne(r => r.Penalty)
         .WithMany()
         .HasForeignKey(r => r.PenaltyId);

      builder.HasIndex(r => new { r.PenaltyId, r.RegulationId }).IsUnique();
   }
}
