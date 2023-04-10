using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
   public void Configure(EntityTypeBuilder<Season> builder)
   {
      builder.HasKey(s => s.Id);

      builder.HasIndex(s => s.Year)
         .IsUnique();

      var navigationCompetitors = builder.Metadata.FindNavigation(nameof(Season.Competitors));
      navigationCompetitors?.SetPropertyAccessMode(PropertyAccessMode.Field);

      builder.HasMany(s => s.Competitors)
         .WithMany()
         .UsingEntity("SeasonCompetitor");

      var navigationCompetitions = builder.Metadata.FindNavigation(nameof(Season.Competitions));
      navigationCompetitions?.SetPropertyAccessMode(PropertyAccessMode.Field);

      builder.
         HasOne(s => s.Regulation)
         .WithMany()
         .HasForeignKey(s => s.RegulationId);
   }
}
