﻿using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

/// <summary>
/// Class <c>Competitor</c> models a competitor in F1 that can compete in a season
/// </summary>

public class Competitor : EntityBase, IAggregateRoot
{
	public string Name { get; set; } = string.Empty;
   public string Location { get; set; } = string.Empty;
   public User? TeamPrincipal { get; set; }
   public string? TeamPrincipalID { get; set; }
   public string PowerUnit { get; set; } = string.Empty;

	public Competitor(int id)
	{
		Id = id;
	}

   public Competitor(string name, string location, User teamPrincipal, string powerUnit)
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
