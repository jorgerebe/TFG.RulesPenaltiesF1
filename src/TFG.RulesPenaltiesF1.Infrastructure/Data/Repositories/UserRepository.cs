using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;
public class UserRepository : IUserRepository
{
   RulesPenaltiesF1DbContext _context;

   public UserRepository(RulesPenaltiesF1DbContext context)
   {
      _context = context;
   }

   public Task<IUser> GetFreeTeamPrincipals()
   {
      throw new NotImplementedException();
   }

   public async Task<IUser> GetTeamPrincipal(string id)
   {
      var user = await _context.Users.Select(u => new {u.Id})
               .ToListAsync();

      if(user == null)
      {
         throw new Exception();
      }

      return null!;

   }
}
