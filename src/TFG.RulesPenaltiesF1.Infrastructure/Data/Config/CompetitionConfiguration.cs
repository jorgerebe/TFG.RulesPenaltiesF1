using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

internal class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
   public void Configure(EntityTypeBuilder<Competition> builder)
   {
      builder.HasOne(c => c.Circuit)
         .WithMany()
         .HasForeignKey(c => c.CircuitId);

      builder.Property(c => c.Week).IsRequired();
      builder.Property(c => c.IsSprint).IsRequired();
      builder.Property(c => c.Name).IsRequired();

      builder.HasIndex(c => new { c.Week, c.SeasonId }).IsUnique();
   }
}
