using AcceptanceTests.Drivers;
using AcceptanceTests.Drivers.PageDrivers;
using AcceptanceTests.PageObjects;

namespace AcceptanceTests.StepDefinitions
{
	[Binding]
   public class HU01_CreateArticlesStepDefinitions
   {

      private readonly ArticlePageObjectModel _articlePageObjectModel;
      private readonly ArticlePageDriver _articlePageDriver;

      public HU01_CreateArticlesStepDefinitions(BrowserDriver browserDriver, ArticlePageDriver articlePageDriver)
      {
         _articlePageObjectModel = new ArticlePageObjectModel(browserDriver.Current);
         _articlePageDriver = articlePageDriver;
      }


      [Given(@"\[The steward is creating an article]")]
      public void GivenTheStewardIsCreatingAnArticle()
      {
         _articlePageObjectModel.EnsureArticlePageIsOpenAndReset();
      }

      [When(@"\[The steward enters the content of the article]")]
      public void WhenTheStewardEntersTheContentOfTheArticle()
      {
         _articlePageObjectModel.EnterContentArticle("article pretty longgg");
      }

      [When(@"\[The steward adds the content of the subarticle as a subitem of the first article]")]
      public void WhenTheStewardAddsTheContentOfTheSubarticleAsASubitemOfTheFirstArticle()
      {
         _articlePageObjectModel.ClickAddSubArticle();
         _articlePageObjectModel.AddContentSubArticle("subarticle1 little longer");
      }

      [When(@"\[The steward submits the article]")]
      public void WhenTheStewardSubmitsTheArticle()
      {
         _articlePageObjectModel.ClickSubmitArticle();
      }

      [Then(@"\[The article created is stored]")]
      public void ThenTheArticleCreatedIsStored()
      {
         var number = _articlePageDriver.getNumberOfArticles();
         _articlePageDriver.getNumberOfArticles().Should().Be(2);
      }
   }
}
