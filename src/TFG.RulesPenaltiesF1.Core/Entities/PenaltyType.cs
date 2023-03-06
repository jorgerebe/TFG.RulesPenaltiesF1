using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class PenaltyType : EntityBase, IAggregateRoot
{
   public string Name { get; private set; }
   public string Description { get; private set; }

   public PenaltyType(int id, string name, string description)
   {
      Id = id;
      Name = name;
      Description = description;
   }
}
