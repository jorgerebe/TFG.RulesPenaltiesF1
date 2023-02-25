using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Article : EntityBase, IAggregateRoot
{
   public string Content { get; private set; }
   private readonly List<Article> _subArticles = new();

   public IReadOnlyCollection<Article> SubArticles => _subArticles.AsReadOnly();

   public Article(string content)
   {
      ArgumentException.ThrowIfNullOrEmpty(content, nameof(content));

      Content = content;
   }

   public void AddSubArticle(Article article)
   {
      ArgumentNullException.ThrowIfNull(article, nameof(article));

      _subArticles.Add(article);
   }

   public void RemoveSubArticle(Article article)
   {
      ArgumentNullException.ThrowIfNull(article, nameof(article));

      _subArticles.Remove(article);
   }

   public void editContent(string newContent)
   {
      ArgumentException.ThrowIfNullOrEmpty(newContent, nameof(newContent));

      this.Content = newContent;
   }
}
