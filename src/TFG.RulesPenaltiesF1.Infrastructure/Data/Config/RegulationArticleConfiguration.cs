using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class RegulationArticleConfiguration : IEntityTypeConfiguration<RegulationArticle>
{
   public void Configure(EntityTypeBuilder<RegulationArticle> builder)
   {
      builder.HasKey(key => new { key.RegulationId, key.ArticleId });

      builder
         .HasOne(r => r.Regulation)
         .WithMany(r => r.Articles)
         .HasForeignKey(r => r.RegulationId);
      
      builder
         .HasOne(r => r.Article)
         .WithMany()
         .HasForeignKey(r => r.ArticleId);

      builder.HasIndex(r => new { r.ArticleId, r.RegulationId }).IsUnique();
   }
}
