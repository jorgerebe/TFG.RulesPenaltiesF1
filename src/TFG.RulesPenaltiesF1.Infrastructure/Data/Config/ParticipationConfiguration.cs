using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

public class ParticipationConfiguration : IEntityTypeConfiguration<Participation>
{
	public void Configure(EntityTypeBuilder<Participation> builder)
	{
		builder.HasKey(p => p.Id);
		builder.HasIndex(p => new { p.DriverId, p.CompetitionId, p.CompetitorId }).IsUnique();
	}
}
