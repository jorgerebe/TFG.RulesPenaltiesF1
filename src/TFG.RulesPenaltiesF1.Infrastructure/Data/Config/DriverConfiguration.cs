using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
	public void Configure(EntityTypeBuilder<Driver> builder)
	{
		builder.Property(d => d.Name).IsRequired();
		builder.Property(d => d.DateBirth).IsRequired();
		builder.Property(d => d.LicensePoints).IsRequired();
		builder.Property(d => d.Competitor).IsRequired();

		builder.HasOne(d => d.Competitor)
			.WithMany()
			.HasForeignKey(d => d.CompetitorId);

		builder.HasIndex(d => d.Name).IsUnique();
	}
}
