namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class PenaltyViewModel
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;

   public PenaltyViewModel() { }

   public PenaltyViewModel(int id, string name, string description)
   {
      Id = id;
      Name = name;
      Description = description;
   }

   public override string ToString()
   {
      return Description;
   }
}
