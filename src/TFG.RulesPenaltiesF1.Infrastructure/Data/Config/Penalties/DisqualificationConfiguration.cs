using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class DisqualificationConfiguration : IEntityTypeConfiguration<Disqualification>
{
   public void Configure(EntityTypeBuilder<Disqualification> builder)
   {
      builder.HasBaseType<Penalty>();
      builder.Property(r => r.NextCompetition).IsRequired();

      builder.HasOne(p => p.PenaltyType)
         .WithMany()
         .HasForeignKey(p => p.PenaltyTypeId);

      builder.HasIndex(r => new { r.NextCompetition, r.PenaltyTypeId })
            .IsUnique();
   }
}
