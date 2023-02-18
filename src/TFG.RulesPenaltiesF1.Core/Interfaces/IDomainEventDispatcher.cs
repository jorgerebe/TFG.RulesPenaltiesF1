
namespace TFG.RulesPenaltiesF1.Core.Interfaces
{
   public interface IDomainEventDispatcher
   {
      Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
   }
}
