using AcceptanceTests.Drivers;

namespace AcceptanceTests.Hooks;
[Binding]
public class WebServerHooks
{
   private readonly WebServerDriver _webServerDriver;

   public WebServerHooks(WebServerDriver webServerDriver)
   {
      _webServerDriver = webServerDriver;
   }

   [BeforeScenario]
   public void StartTestServer()
   {
      this._webServerDriver.Start();
   }

   [AfterScenario]
   public async Task StopTestServer()
   {
      await this._webServerDriver.Stop();
   }
}
