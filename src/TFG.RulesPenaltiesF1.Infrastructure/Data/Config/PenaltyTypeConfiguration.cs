using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
internal class PenaltyTypeConfiguration : IEntityTypeConfiguration<PenaltyType>
{
   public void Configure(EntityTypeBuilder<PenaltyType> builder)
   {
      builder.HasKey(pt => pt.Id);

      builder.Property(pt => pt.Name)
         .HasMaxLength(50)
         .IsRequired();

      builder.Property(pt => pt.Description)
         .HasMaxLength(140)
         .IsRequired();
   }
}
