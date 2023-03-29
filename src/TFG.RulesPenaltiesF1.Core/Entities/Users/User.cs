namespace TFG.RulesPenaltiesF1.Core.Entities.Users;
public class User : IUser
{
   public string Id { get; set; }
   public string? Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
   public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
   public string Role { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

   public User(string id, string email, string fullName, string role)
   {
      Id = id;
      Email = email;
      FullName = fullName;
      Role = role;
   }

   public User(string id, string fullName, string role)
   {
      Id = id;
      FullName = fullName;
      Role = role;
   }
}
