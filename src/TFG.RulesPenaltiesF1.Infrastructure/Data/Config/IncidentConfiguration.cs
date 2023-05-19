﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;

public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
	public void Configure(EntityTypeBuilder<Incident> builder)
	{
		builder.HasKey(i => i.Id);

		builder.HasOne(i => i.Participation)
			.WithMany()
			.HasForeignKey(d => d.ParticipationId);

		builder.HasOne(i => i.Session)
			.WithMany()
			.HasForeignKey(d => d.SessionId).OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(i => i.Article)
			.WithMany()
			.HasForeignKey(d => d.ArticleId);

		builder.HasOne(i => i.Penalty)
			.WithMany()
			.HasForeignKey(d => d.PenaltyId);

		builder.Property(i => i.Created).IsRequired();
		builder.Property(i => i.Fact).IsRequired();
		builder.Property(i => i.Reason).IsRequired();
	}
}
