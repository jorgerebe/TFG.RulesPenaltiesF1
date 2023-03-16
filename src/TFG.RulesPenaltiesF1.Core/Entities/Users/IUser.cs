namespace TFG.RulesPenaltiesF1.Core.Entities.Users;
public interface IUser
{
   string Name { get; set; }
   string Email { get; set; }

   List<string> Roles { get; set; }
}
