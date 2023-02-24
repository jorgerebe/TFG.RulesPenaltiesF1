using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AcceptanceTests.Drivers;
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
   public string HostUrl { get; set; } = "http://localhost:33333"; // we can use any free port

   protected override void ConfigureWebHost(IWebHostBuilder builder)
   {
      builder.UseEnvironment("Testing");
      Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
      builder.UseUrls(HostUrl);
   }
   protected override IHost CreateHost(IHostBuilder builder)
   {
      var dummyHost = builder.Build();
      builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());
      var host = builder.Build();
      host.Start();
      return dummyHost;
   }
}

