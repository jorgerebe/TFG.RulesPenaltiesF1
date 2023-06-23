using TFG.RulesPenaltiesF1.Core.Entities.Users;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
public interface IUserRepository
{
   public Task<IUser> GetTeamPrincipal(string id);
   public Task<IUser> GetFreeTeamPrincipals();
}
