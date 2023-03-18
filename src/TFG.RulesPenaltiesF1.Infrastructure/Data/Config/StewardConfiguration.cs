using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class StewardConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
   public void Configure(EntityTypeBuilder<ApplicationUser> builder)
   {
      builder.Property(user => user.FullName).IsRequired();
   }
}
