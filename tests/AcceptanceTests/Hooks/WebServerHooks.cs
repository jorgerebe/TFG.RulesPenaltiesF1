using AcceptanceTests.Drivers;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Web;

namespace AcceptanceTests.Hooks;
[Binding]
public class WebServerHooks
{
   private static WebServerDriver? _webServerDriver;

   [BeforeTestRun]
   public static void StartTestServer(WebServerDriver webServerDriver)
   {
      _webServerDriver = webServerDriver;
      _webServerDriver.Start();
   }

   //[AfterTestRun]
   /*public static async Task StopTestServer()
   {
      //await _webServerDriver!.Stop();
   }*/
}
