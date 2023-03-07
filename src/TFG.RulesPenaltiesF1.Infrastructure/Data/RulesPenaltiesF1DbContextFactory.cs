using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;
public class RulesPenaltiesF1DbContextFactory : IDesignTimeDbContextFactory<RulesPenaltiesF1DbContext>
{
   public RulesPenaltiesF1DbContext CreateDbContext(string[] args)
   {
      var optionsBuilder = new DbContextOptionsBuilder<RulesPenaltiesF1DbContext>();
      optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

      return new RulesPenaltiesF1DbContext(optionsBuilder.Options);
   }
}
