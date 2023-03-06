using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
   public void Configure(EntityTypeBuilder<Penalty> builder)
   {
      builder.HasKey(p => p.Id);
      builder.Property(p => p.PenaltyTypeId).IsRequired();

      builder.HasOne(p => p.PenaltyType)
         .WithMany()
         .HasForeignKey(p => p.PenaltyTypeId);
   }
}
