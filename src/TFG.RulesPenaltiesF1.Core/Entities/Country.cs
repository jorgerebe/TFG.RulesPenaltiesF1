using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

/// <summary>
/// Class <c>Country</c> models a country where a circuit is.
/// </summary>

public class Country : EntityBase, IAggregateRoot
{
   public string Name { get; set; }

   public Country(string name)
   {
      Name = name;
   }

   public Country(int id, string name)
   {
      Id = id;
      Name = name;
   }
}
