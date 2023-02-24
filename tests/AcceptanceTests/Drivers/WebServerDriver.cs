using Microsoft.AspNetCore.Mvc.Testing;

namespace AcceptanceTests.Drivers;
public class WebServerDriver
{
   private CustomWebApplicationFactory<Program>? _factory;

   public async void Start()
   {
      _factory = new CustomWebApplicationFactory<Program>();
      var client = _factory.CreateClient();
      await client.GetAsync("/Home");
   }  

   public async Task Stop()
   {
      if(_factory != null)
      {
         await _factory.DisposeAsync();
      }
   }

   public string getUrl()
   {
      return _factory!.HostUrl;
   }
}
