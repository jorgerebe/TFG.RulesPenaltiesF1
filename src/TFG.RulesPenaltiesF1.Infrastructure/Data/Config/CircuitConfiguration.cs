using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class CircuitConfiguration : IEntityTypeConfiguration<Circuit>
{
   public void Configure(EntityTypeBuilder<Circuit> builder)
   {
      builder.HasKey(ci => ci.Id);

      builder.HasOne(p => p.Country)
         .WithMany()
         .HasForeignKey(p => p.CountryId);

      builder.Property(p => p.Name)
          .HasMaxLength(100)
          .IsRequired();

      builder.Property(p => p.Length)
          .IsRequired();

      builder.Property(p => p.Laps)
          .IsRequired();

      builder.Property(p => p.YearFirstGP)
          .IsRequired();

      builder.Property(p => p.MillisecondsLapRecord)
          .IsRequired();

      builder.Property(p => p.DriverLapRecord)
          .IsRequired();

      builder.Property(p => p.YearLapRecord)
          .IsRequired();

      builder.HasIndex(c => c.Name)
         .IsUnique();
   }
}
