using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CircuitViewModelService : ICircuitViewModelService
{
   private readonly IRepository<Circuit> _repository;
   public CircuitViewModelService(IRepository<Circuit> repository)
   {
      _repository = repository;
   }
}
