using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;

public class CompetitorRepository : EfRepository<Competitor>, ICompetitorRepository
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public CompetitorRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<Competitor?> GetCompetitorById(int id)
   {
      var competitor = await _dbContext.Competitor
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();

      if(competitor is null)
      {
         return null;
      }

      if(competitor.TeamPrincipalID is null)
      {
         return competitor;
      }

      var applicationUser = await _dbContext.User
                    .Where(u => u.Id == competitor.TeamPrincipalID)
                    .FirstOrDefaultAsync();

      if(applicationUser is null)
      {
         return competitor;
      }

      User user = new User(applicationUser.Id, applicationUser.FullName);

      competitor.TeamPrincipal = user;
      return competitor;
   }

   public async Task<List<IUser>> GetTeamPrincipals()
   {
      List<IUser> usuarios = new ();

      var usersWithoutTeamPrincipal = await _dbContext.User.Select(u => new {u.Id, u.FullName})
        .Where(u => _dbContext.UserRoles
        .Any(ur => ur.UserId == u.Id &&
                   _dbContext.Roles
                       .Any(r => r.Id == ur.RoleId && r.Name == "TeamPrincipal")))
         .GroupJoin(
           _dbContext.Competitor,
           user => user.Id,
           competitor => competitor.TeamPrincipalID,
           (user, competitors) => new { User = user, Competitor = competitors.FirstOrDefault() }
       )
       .Where(joinResult => joinResult.Competitor == null)
       .Select(joinResult => joinResult.User)
       .ToListAsync();

      foreach(var user in usersWithoutTeamPrincipal)
      {
         usuarios.Add(new User(user.Id, user.FullName));
      }

      return usuarios;
   }

	public async Task<List<Competitor>> GetAllCompetitorsWithTeamPrincipals()
	{
		return await _dbContext.Set<Competitor>()
			.Where(c => c.TeamPrincipalID != null)
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task<bool> ExistsCompetitorByName(string name)
   {
      return await _dbContext.Set<Competitor>().AnyAsync(r => r.Name.ToLower() == name.ToLower());
   }

	public async Task<Competitor?> GetCompetitorByTeamPrincipalId(string teamPrincipalId)
	{
		return await _dbContext.Set<Competitor>()
			.Where(c => c.TeamPrincipalID == teamPrincipalId).FirstOrDefaultAsync();
	}
}
