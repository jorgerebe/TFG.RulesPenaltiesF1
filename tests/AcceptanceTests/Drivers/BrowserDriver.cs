﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AcceptanceTests.Drivers;
public class BrowserDriver : IDisposable
{
   private Lazy<IWebDriver> _currentWebDriverLazy;
   private bool _isDisposed;

   public BrowserDriver()
   {
      _currentWebDriverLazy = new Lazy<IWebDriver>((CreateWebDriver));
   }

   public IWebDriver Current => _currentWebDriverLazy.Value;

   private IWebDriver CreateWebDriver()
   {
      var chromeDriverService = ChromeDriverService.CreateDefaultService();
      var chromeOptions = new ChromeOptions();
      var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

      return chromeDriver;
   }

   public void Dispose()
   {
      if (_isDisposed)
      {
         return;
      }

      if (_currentWebDriverLazy.IsValueCreated)
      {
         Current.Quit();
      }

      _isDisposed = true;
   }
}
