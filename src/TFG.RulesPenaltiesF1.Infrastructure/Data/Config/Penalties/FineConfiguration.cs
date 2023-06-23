using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config.Penalties;
public class FineConfiguration : IEntityTypeConfiguration<Fine>
{
   public void Configure(EntityTypeBuilder<Fine> builder)
   {
      builder.HasBaseType<Penalty>();
   }
}
