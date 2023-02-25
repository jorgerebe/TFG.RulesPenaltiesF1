using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Drivers;
public class BrowserDriver
{
   private readonly WebDriverDriver _webDriverDriver;

   public BrowserDriver(WebDriverDriver webDriverDriver)
   {
      _webDriverDriver = webDriverDriver;
   }

   public string Title
   {
      get { return _webDriverDriver.WebDriver.Title; }
   }

   public void AssertTitle(string expectedTitle)
   {
      Title.Should().Be(expectedTitle);
   }

   internal void GoToUrl(string url)
   {
      _webDriverDriver.WebDriver.Url = url;
   }
}
