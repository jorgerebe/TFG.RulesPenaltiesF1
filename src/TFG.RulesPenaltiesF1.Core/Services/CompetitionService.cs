using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;

public class CompetitionService : ICompetitionService
{
	private readonly ICompetitionRepository _repository;
	private readonly IRegulationRepository _regulationRepository;

	public CompetitionService(ICompetitionRepository repository, IRegulationRepository regulationRepository)
	{
		_repository = repository;
		_regulationRepository = regulationRepository;
	}

	public async Task<Competition> StartCompetition(int id)
	{
		Competition? competition = await _repository.GetByIdAsync(id) ?? throw new ArgumentException($"Competition with id {id} could not be found");

		competition.StartCompetition();

		await _repository.Update(competition);
		return competition;
	}

	public async Task AddParticipations(List<Participation> participations)
	{
		ArgumentNullException.ThrowIfNull(participations);

		if (participations.Count == 0)
		{
			throw new ArgumentException("Can not add 0 participations");
		}

		if (participations.DistinctBy(p => p.DriverId).Count() < participations.Count)
		{
			throw new ArgumentException("The same driver can not participate twice in the same competition");
		}

		if (participations.DistinctBy(p => p.CompetitionId).Count() != 1)
		{
			throw new ArgumentException("A participation from other competitions can not be added to this competition");
		}

		if (participations.DistinctBy(p => p.CompetitorId).Count() != 1)
		{
			throw new ArgumentException("A participation with more than one competitor can not be added");
		}

		int competitionId = participations[0].CompetitionId;

		Competition? competition = await _repository.GetCompetitionByIdWithParticipationsAsync(competitionId) ?? throw new ArgumentException("The participations are from a competition that does not exist.");

		competition.AddParticipations(participations);

		await _repository.Update(competition);
	}

	public async Task AdvanceSession(int id)
	{
		Competition? competition = await _repository.GetCompetitionByIdWithSessionsAsync(id) ?? throw new ArgumentException($"The competition with id {id} does not exist.");

		competition.Advance();

		await _repository.Update(competition);
	}

	public async Task AddIncident(Incident incident)
	{
		Competition? competition = await _repository.GetCompetitionBySessionId(incident.SessionId) ?? throw new ArgumentException($"The competition with session with id {incident.SessionId} does not exist.");

		Regulation? regulation = await _regulationRepository.GetRegulationByCompetitionId(competition.Id) ?? throw new ArgumentException($"The regulation of the competition with id {competition.Id} does not exist");

		if(!regulation.Articles.Any(a => a.ArticleId == incident.ArticleId))
		{
			throw new ArgumentException("The article specified in the incident is not part of the regulations of the season");
		}

		if(incident.PenaltyId is not null && !regulation.Penalties.Any(p => p.PenaltyId == incident.PenaltyId))
		{
			throw new ArgumentException("The article specified in the incident is not part of the regulations of the season");
		}

		incident.Created = DateTime.Now;

		competition.AddIncident(incident, competition.Sessions.Where(s => s.Id == incident.SessionId).First());

		await _repository.Update(competition);
	}
}
