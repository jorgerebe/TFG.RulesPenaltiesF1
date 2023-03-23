using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Country : EntityBase, IAggregateRoot
{
   public string Name { get; set; }

   public Country(string name)
   {
      Name = name;
   }
}
