using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests.Drivers;
public class RegulationPageDriver
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public RegulationPageDriver(RulesPenaltiesF1DbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public bool existsRegulationWithName(string name)
   {
      var regulation = _dbContext.Regulation.
         Where(r => r.Name == name);

      return regulation != null;
   }
}
