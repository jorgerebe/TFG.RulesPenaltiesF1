﻿using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.PageObjects;
public class RegulationPageObjectModel
{
   private const string RegulationUrl = "https://localhost:33333/Regulations/Create";

   private readonly IWebDriver _webDriver;

   public const int DefaultWaitInSeconds = 5;

   public RegulationPageObjectModel(IWebDriver webDriver)
   {
      _webDriver = webDriver;
   }
   private IWebElement NameRegulation => _webDriver.FindElement(By.Id("Name"));
   private IWebElement Articles => _webDriver.FindElement(By.Id("Articles"));
   private SelectElement ArticlesSelect => new SelectElement(Articles);
   private IWebElement Penalties => _webDriver.FindElement(By.Id("Penalties"));
   private SelectElement PenaltiesSelect => new SelectElement(Penalties);
   private IWebElement SubmitRegulation => _webDriver.FindElement(By.Id("submit"));
   private IWebElement ResetButton => _webDriver.FindElement(By.Id("reset"));

   public void EnterNameRegulation(string name)
   {
      NameRegulation.Clear();
      NameRegulation.SendKeys(name);
   }

   public void SelectArticle(int number)
   {
      ArticlesSelect.SelectByIndex(number);
   }

   public void SelectPenalty(int number)
   {
      PenaltiesSelect.SelectByIndex(number);
   }

   public void ClickSubmitRegulation()
   {
      ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", SubmitRegulation);
      Thread.Sleep(1000);
      SubmitRegulation.Click();
   }

   public void EnsureRegulationPageIsOpenAndReset()
   {
      if (_webDriver.Url != RegulationUrl)
      {
         _webDriver.Url = RegulationUrl;
      }
      else
      {
         ResetButton.Click();
      }

   }
}
