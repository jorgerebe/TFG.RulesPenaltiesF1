using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

/// <summary>
/// Class <c>Article</c> models an article from a regulation.
/// </summary>

public class Article : EntityBase, IAggregateRoot
{
   public string Content { get; private set; }
   private readonly List<Article> _subArticles = new();

   public IReadOnlyCollection<Article> SubArticles => _subArticles.AsReadOnly();

   public Article(string content)
   {
      ArgumentException.ThrowIfNullOrEmpty(content, nameof(content));

      if(content.Length < 10)
      {
         throw new ArgumentException("Content of article should be at least 10 characters long");
      }

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

      if (!_subArticles.Contains(article))
      {
         throw new ArgumentException("The article does not contain the subarticle you are trying to remove");
      }

      _subArticles.Remove(article);
   }

   public void EditContent(string newContent)
   {
      ArgumentException.ThrowIfNullOrEmpty(newContent, nameof(newContent));

      Content = newContent;
   }
}
