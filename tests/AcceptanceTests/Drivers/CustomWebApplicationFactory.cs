using System.Data.Common;
using AcceptanceTests.Support;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests.Drivers;
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{

   public static int Port = 33333;

   public static string HostUrl = "http://localhost:"+ Port; // we can use any free port

   protected override void ConfigureWebHost(IWebHostBuilder builder)
   {
      builder.ConfigureServices(services =>
      {
         builder.ConfigureServices(services =>
         {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<RulesPenaltiesF1DbContext>));

            services.Remove(dbContextDescriptor!);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbConnection));

            services.Remove(dbConnectionDescriptor!);


            services.AddDbContext<RulesPenaltiesF1DbContext>((container, options) =>
            {
               options.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });

            using var scope = services.BuildServiceProvider().CreateScope();
            var provider = scope.ServiceProvider;

            // Resolve the DbContext from the container and apply pending migrations
            var dbContext = provider.GetRequiredService<RulesPenaltiesF1DbContext>();
         });
      });



      builder.ConfigureServices(services =>
      {
         var builder = new ContainerBuilder();

         ScenarioDependencies.RegisterDependencies(builder);
         builder.Populate(services);
      });

      builder.UseEnvironment("Development");
      Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
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

