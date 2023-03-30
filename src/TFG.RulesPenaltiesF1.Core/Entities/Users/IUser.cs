namespace TFG.RulesPenaltiesF1.Core.Entities.Users;
public interface IUser
{
   public string Id { get; set; }
   public string? Email { get; set;}
   public string FullName { get; set;}
}
