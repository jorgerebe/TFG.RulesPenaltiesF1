using Autofac;
using Autofac.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Infrastructure;
using Serilog;
using TFG.RulesPenaltiesF1.Web.Configuration;
using TFG.RulesPenaltiesF1.Web;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);


Console.WriteLine(environment);
Console.WriteLine(connectionString!);

builder.Services.AddDbContext(connectionString!);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(false));
});


/*END IDENTITY*/

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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
app.UseAuthorization();

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

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await SeedDataIdentity.SeedAsync(userManager, roleManager);
    await SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}

app.Run();
