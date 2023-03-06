﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class StopAndGoConfiguration : IEntityTypeConfiguration<StopAndGo>
{
   public void Configure(EntityTypeBuilder<StopAndGo> builder)
   {
      builder.HasBaseType<DriveThrough>();
      builder.Property(r => r.ElapsedSeconds).IsRequired(false);
      builder.Property(r => r.Seconds).IsRequired(false);

      builder.HasIndex(r => new { r.ElapsedSeconds, r.Seconds, r.PenaltyTypeId })
            .IsUnique();
   }
}