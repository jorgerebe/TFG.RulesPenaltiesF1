using OpenQA.Selenium;

namespace AcceptanceTests.PageObjects;
public class ArticlePageObjectModel
{
   private const string ArticleUrl = "http://localhost:33333/Articles/Create";

   private readonly IWebDriver _webDriver;

   public const int DefaultWaitInSeconds = 5;

   public ArticlePageObjectModel(IWebDriver webDriver)
   {
      _webDriver= webDriver;
   }

   private int numberSubArticle = 0;

   private IWebElement ContentArticle => _webDriver.FindElement(By.Id("Content"));
   private IWebElement AddSubArticle => _webDriver.FindElement(By.Id("idAdSubarticle"));
   private IWebElement RemoveSubArticle => _webDriver.FindElement(By.Id("idRemoveSubarticle"));
   private IWebElement SubmitArticle => _webDriver.FindElement(By.Id("submit"));
   private IWebElement ResetButton => _webDriver.FindElement(By.Id("resetButton"));
   private IWebElement GetSubArticle(int subarticle)
   {
      return _webDriver.FindElement(By.Id("SubArticles_"+numberSubArticle+"__Content"));
   }

   public void EnterContentArticle(string content)
   {
      ContentArticle.Clear();
      ContentArticle.SendKeys(content);
   }

   public void ClickAddSubArticle()
   {
      numberSubArticle++;
      AddSubArticle.Click();
   }

   public void ClickRemoveSubArticle()
   {
      if(numberSubArticle > 0)
      {
         numberSubArticle--;
         RemoveSubArticle.Click();
      }
   }

   public void AddContentSubArticle(string content)
   {
      GetSubArticle(numberSubArticle).Clear();
      GetSubArticle(numberSubArticle).SendKeys(content);
   }

   public void ClickSubmitArticle()
   {
      SubmitArticle.Click();
   }

   public void EnsureCalculatorIsOpenAndReset()
   {
      //Open the calculator page in the browser if not opened yet
      if (_webDriver.Url != ArticleUrl)
      {
         _webDriver.Url = ArticleUrl;
      }
      //Otherwise reset the calculator by clicking the reset button
      else
      {
         ResetButton.Click();
      }
   }

}
