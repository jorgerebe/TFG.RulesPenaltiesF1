using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
public interface IPenaltyRepository : IRepository<Penalty>
{
   Task<List<Penalty>> GetAllPenalties();
	Task<Penalty?> GetLimitLicensePointsPenalty();
	Task<PenaltyType?> GetPenaltyTypeByName(string name);
	Task<PenaltyType> AddPenaltyType(PenaltyType penaltyType);
}
