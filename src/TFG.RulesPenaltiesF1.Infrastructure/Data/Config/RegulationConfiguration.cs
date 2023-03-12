using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class RegulationConfiguration : IEntityTypeConfiguration<Regulation>
{
   public void Configure(EntityTypeBuilder<Regulation> builder)
   {
      builder.HasKey(ci => ci.Id);

      builder
         .HasMany(r => r.Articles)
         .WithOne(r => r.Regulation)
         .HasForeignKey(r => r.RegulationId);

      builder.Property(r => r.Name)
         .IsRequired();

      builder.HasIndex(r => r.Name).IsUnique();
   }
}
