﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class TimePenaltyConfiguration : IEntityTypeConfiguration<TimePenalty>
{
   public void Configure(EntityTypeBuilder<TimePenalty> builder)
   {
      builder.HasBaseType<Penalty>();
      builder.Property(r => r.Seconds).IsRequired();
      builder.HasIndex(r => new { r.Seconds, r.PenaltyTypeId })
            .IsUnique();
   }
}
