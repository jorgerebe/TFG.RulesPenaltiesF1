using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TFG.RulesPenaltiesF1.Core;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;
public class RulesPenaltiesF1DbContextFactory : IDesignTimeDbContextFactory<RulesPenaltiesF1DbContext>
{

   RulesPenaltiesF1DbContext IDesignTimeDbContextFactory<RulesPenaltiesF1DbContext>.CreateDbContext(string[] args)
   {
      var optionsBuilder = new DbContextOptionsBuilder<RulesPenaltiesF1DbContext>();
      optionsBuilder.UseSqlServer("Server=YourServer; Database=YourDb; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");

      return new RulesPenaltiesF1DbContext(optionsBuilder.Options);
   }
}
