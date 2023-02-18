using Autofac;
using Autofac.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Infrastructure;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Web;
using Serilog;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);


if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
{
   var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri")!);
   builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
}


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

string? connectionString = builder.Configuration["DefaultConnection"];

builder.Services.AddDbContext(connectionString!);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
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
    //                    context.Database.Migrate();
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
