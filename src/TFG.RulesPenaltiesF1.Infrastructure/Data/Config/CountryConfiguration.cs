using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
   public void Configure(EntityTypeBuilder<Country> builder)
   {
      builder.HasKey(ci => ci.Id);

      builder.Property(p => p.Name)
          .HasMaxLength(50)
          .IsRequired();
   }
}
