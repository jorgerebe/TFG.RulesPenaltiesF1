using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
{
   public void Configure(EntityTypeBuilder<Competitor> builder)
   {
      builder.HasKey(c => c.Id);

      builder.HasOne(c => c.TeamPrincipal)
                   .WithOne()
                   .HasForeignKey<Competitor>(c => c.TeamPrincipalID)
                   .OnDelete(DeleteBehavior.Restrict);

      builder.Property(c => c.Name)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(c => c.Location)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(c => c.PowerUnit)
             .IsRequired()
             .HasMaxLength(100);
   }
}
