using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Competitor : EntityBase, IAggregateRoot
{
   public string Name { get; set; }
   public string Location { get; set; }
   public IdentityUser? TeamPrincipal { get; set; }
   public string? TeamPrincipalID { get; set; }
   public string PowerUnit { get; set; }

   public Competitor(string name, string location, IdentityUser teamPrincipal, string powerUnit)
   {
      Name = name;
      Location = location;
      TeamPrincipal = teamPrincipal;
      TeamPrincipalID = teamPrincipal.Id;
      PowerUnit = powerUnit;
   }

   public Competitor(string name, string location, string teamPrincipalId, string powerUnit)
   {
      Name = name;
      Location = location;
      TeamPrincipalID = teamPrincipalId;
      PowerUnit = powerUnit;
   }

   public Competitor(string name, string location, string powerUnit)
   {
      Name = name;
      Location = location;
      PowerUnit = powerUnit;
   }
}
