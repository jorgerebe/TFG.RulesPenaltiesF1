using MediatR;

namespace TFG.RulesPenaltiesF1.Core
{
   public abstract class DomainEventBase : INotification
   {
      public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
   }
}
