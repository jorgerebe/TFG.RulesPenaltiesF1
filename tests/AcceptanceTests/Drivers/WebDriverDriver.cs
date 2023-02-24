using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AcceptanceTests.Drivers;
public class WebDriverDriver
{
   private Lazy<IWebDriver> _webDriver;

   public WebDriverDriver()
   {
      _webDriver = new Lazy<IWebDriver>(() => CreateWebDriver());
   }

   private IWebDriver CreateWebDriver()
   {
      return new ChromeDriver()
      {

      };
   }

   public IWebDriver WebDriver
   {
      get
      {
         return _webDriver.Value;
      }
   }
}
