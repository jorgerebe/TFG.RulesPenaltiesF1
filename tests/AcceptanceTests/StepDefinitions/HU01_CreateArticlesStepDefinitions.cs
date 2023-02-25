using System;
using AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
   [Binding]
   public class HU01_CreateArticlesStepDefinitions
   {

      private readonly WebDriverDriver _webDriverDriver;
      private readonly WebServerDriver _webServerDriver;
      private readonly BrowserDriver _browserDriver;

      public string HostUrl { get; private set; }

      public HU01_CreateArticlesStepDefinitions(WebDriverDriver webDriverDriver, WebServerDriver webServerDriver, BrowserDriver browserDriver)
      {
         _webDriverDriver = webDriverDriver;
         _webServerDriver = webServerDriver;
         HostUrl = _webServerDriver.getUrl();
         _browserDriver = browserDriver;
      }
        
   
      [Given(@"\[The steward is creating an article]")]
      public void GivenTheStewardIsCreatingAnArticle()
      {
         _browserDriver.GoToUrl(_webServerDriver.getUrl() + "/Home");
      }

      [When(@"\[The steward enters the content of the article]")]
      public void WhenTheStewardEntersTheContentOfTheArticle()
      {
         //this._webDriverDriver.WebDriver.Url = "http://localhost:31213/Articles";
      }

      [When(@"\[The steward adds the content of the subarticle as a subitem of the first article]")]
      public void WhenTheStewardAddsTheContentOfTheSubarticleAsASubitemOfTheFirstArticle()
      {
         //throw new PendingStepException();
      }

      [When(@"\[The steward submits the article]")]
      public void WhenTheStewardSubmitsTheArticle()
      {
         //throw new PendingStepException();
      }

      [Then(@"\[The article created should have one subarticle]")]
      public void ThenTheArticleCreatedShouldHaveOneSubarticle()
      {
         _browserDriver.AssertTitle("pepe");
      }
   }
}
