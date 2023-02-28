﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Infrastructure;
using Serilog;
using Azure.Identity;
using TFG.RulesPenaltiesF1.Web.Configuration;
using TFG.RulesPenaltiesF1.Web;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var key = "Testing";

switch(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
{
   case "Production":
      var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri")!);
      builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
      break;
   case "Development":
      break;
   case "Testing":
      key = "Testing";
      break;
   default:
      break;
}

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

string? connectionString = builder.Configuration["DefaultConnection" + key];


builder.Services.AddDbContext("Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", environment=="Testing");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(environment == "Testing"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<RulesPenaltiesF1DbContext>();
    //context.Database.Migrate();
    context.Database.EnsureCreated();
    SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

app.Run();
