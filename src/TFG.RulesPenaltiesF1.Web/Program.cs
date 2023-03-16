using Autofac;
using Autofac.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Infrastructure;
using Serilog;
using Azure.Identity;
using TFG.RulesPenaltiesF1.Web.Configuration;
using TFG.RulesPenaltiesF1.Web;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Autofac.Core;
using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

string? connectionString = "";

switch(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
{
   case "Production":
      connectionString = "Server=tcp:tfg-jorgerebemartin.database.windows.net,1433;Initial Catalog=RulesPenaltiesF1;Persist Security Info=False;User ID=jorrebe;Password=Pepe1234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
      /*var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri")!);
      builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new EnvironmentCredential());
      Console.WriteLine("\n\n\n" + builder.Configuration["DefaultConnection"] + "\n\n\n");*/
      break;
   case "Development":
      connectionString = builder.Configuration["DefaultConnection"];
      break;
   case "Testing":
      connectionString = "Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//builder.Configuration["DefaultConnectionTesting"];
      break;
   default:
      connectionString = builder.Configuration["DefaultConnection"];
      break;
}

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

//string? connectionString = builder.Configuration["DefaultConnection" + key];

Console.WriteLine(environment);
Console.WriteLine(connectionString!);

builder.Services.AddDbContext(connectionString!);

builder.Services.AddScoped<RulesPenaltiesF1DbContext, RulesPenaltiesF1DbContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(false));
});


/*END IDENTITY*/

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
   options.User.RequireUniqueEmail = true;
   options.Password.RequireNonAlphanumeric = false;
   options.Password.RequireUppercase = false;
   options.Password.RequireLowercase = false;
   options.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<RulesPenaltiesF1DbContext>()
.AddDefaultUI()
.AddDefaultTokenProviders();

/*END IDENTITY*/

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

/**/

app.UseAuthentication();

/**/

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
