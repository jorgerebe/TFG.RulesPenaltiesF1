using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CompetitionViewModelService : ICompetitionViewModelService
{
	private readonly ICompetitionRepository _repository;

	public CompetitionViewModelService(ICompetitionRepository repository)
	{
		_repository = repository;
	}

	public async Task<CompetitionViewModel?> GetByIdAsync(int id)
	{
		Competition? competition = await _repository.GetCompetitionById(id);

		if(competition is null)
		{
			return null;
		}

		return MapEntityToViewModel(competition);
	}

	public async Task<bool> CanStartCompetition(int id)
	{
		Competition? competition = await _repository.GetNextCompetitionThatCanBeStarted();

		if(competition == null)
		{
			return false;
		}

		if (competition.Id == id)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public CompetitionViewModel MapEntityToViewModel(Competition competition)
	{
		ArgumentNullException.ThrowIfNull(competition);

		return new CompetitionViewModel()
		{
			SeasonId = competition.Season!.Id,
			Year = competition.Season!.Year,
			Id = competition.Id,
			Name = competition.Name,
			CircuitId = competition.CircuitId,
			Circuit = new() { Name = competition.Circuit!.Name },
			IsSprint = competition.IsSprint,
			Week = competition.Week,
			CompetitionState = competition.CompetitionState
		};
	}

	public Competition? MapViewModelToEntity(CompetitionViewModel competition)
	{
		throw new NotImplementedException();
	}
}
