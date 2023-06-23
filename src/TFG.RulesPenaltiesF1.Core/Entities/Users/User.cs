namespace TFG.RulesPenaltiesF1.Core.Entities.Users;
public class User : IUser
{
   public string Id { get; set; }
   public string? Email { get; set; }
   public string FullName { get; set; }

   public User(string id, string email, string fullName)
   {
      Id = id;
      Email = email;
      FullName = fullName;
   }

   public User(string id, string fullName)
   {
      Id = id;
      FullName = fullName;
   }
}
