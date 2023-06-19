using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

internal class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
   public void Configure(EntityTypeBuilder<Competition> builder)
   {
		builder.HasKey(c => c.Id);

      builder.HasOne(c => c.Circuit)
         .WithMany()
         .HasForeignKey(c => c.CircuitId);

      builder.Property(c => c.Week).IsRequired();
      builder.Property(c => c.IsSprint).IsRequired();
      builder.Property(c => c.Name).IsRequired();
      builder.Property(c => c.State).IsRequired();

      builder.HasIndex(c => new { c.Week, c.SeasonId }).IsUnique();

		var navigationSessions = builder.Metadata.FindNavigation(nameof(Competition.Sessions));
		navigationSessions?.SetPropertyAccessMode(PropertyAccessMode.Field);

		builder.Navigation(c => c.Participations).AutoInclude();
		builder.Navigation(c => c.Season).AutoInclude();
	}
}
