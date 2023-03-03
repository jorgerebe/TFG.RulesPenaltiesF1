using FluentAssertions;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace UnitTests.Core.Entities;
public class ArticleTests
{
   [Fact]
   public void Constructor_ContentNotEmpty()
   {
      var article = new Article("content not empty");
      article.Content.Should().BeSameAs("content not empty");
      article.SubArticles.Should().HaveCount(0);
   }

   [Fact]
   public void Constructor_ContentFewerThan10Chars_ThrowsException()
   {
      Action action = () => { new Article("short"); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_ContentEmpty_ThrowsNullException()
   {
      Action action = () => { new Article(""); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_ContentNull_ThrowsNullException()
   {
      Action action = () => { new Article(null!); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void AddSubArticle_NotNull()
   {
      var article1 = new Article("content not empty");
      var article2 = new Article("content subarticle1 not empty");
      article1.AddSubArticle(article2);
      Assert.Single(article1.SubArticles);
      article1.SubArticles.First().Content.Should().BeSameAs("content subarticle1 not empty");
   }

   [Fact]
   public void AddSubArticle_ThrowsNullException()
   {
      Article article = new Article("content not empty");

      Action action = () => { article.AddSubArticle(null!); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }
   
   [Fact]
   public void RemoveSubArticle_NotNull()
   {
      var article1 = new Article("content not empty");
      var article2 = new Article("content subarticle1 not empty");
      article1.AddSubArticle(article2);

      article1.RemoveSubArticle(article2);
      
   }

   [Fact]
   public void RemoveSubArticle_ThrowsNullException()
   {
      Article article1 = new Article("content not empty");
      var article2 = new Article("content subarticle1 not empty");
      article1.AddSubArticle(article2);

      Action action = () => { article1.RemoveSubArticle(null!); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void RemoveSubArticle_DoesNotExist_ThrowsException()
   {
      Article article1 = new Article("content not empty");
      var article2 = new Article("content subarticle1 not empty");

      Action action = () => { article1.RemoveSubArticle(article1); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("The article does not contain the subarticle you are trying to remove");
   }

   [Fact]
   public void EditContent_NotNull()
   {
      Article article1 = new Article("content not empty");
      article1.EditContent("new content of article");

      article1.Content.Should().BeEquivalentTo("new content of article");
   }

   [Fact]
   public void EditContent_ThrowsNullException()
   {
      Article article1 = new Article("content not empty");

      Action action = () => { article1.EditContent(null!); };

      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }
}
