using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Config;
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{

   public void Configure(EntityTypeBuilder<Article> builder)
   {
      var navigation = builder.Metadata.FindNavigation(nameof(Article.SubArticles));
      navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

      builder.HasKey(ci => ci.Id);

      builder.Property(p => p.Content)
          .HasMaxLength(1000)
          .IsRequired();
   }
}
