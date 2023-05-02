using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;

public class CompetitionService : ICompetitionService
{
	private readonly ICompetitionRepository _repository;

	public CompetitionService(ICompetitionRepository repository)
	{
		_repository = repository;
		}

	public async Task<Competition> StartCompetition(int id)
	{
		Competition? competition = await _repository.GetCompetitionById(id);

		if(competition is null)
		{
			throw new ArgumentException($"Competition with id {id} could not be found");
		}

		competition.StartCompetition();

		await _repository.Update(competition);
		return competition;
	}
}
