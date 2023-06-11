using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SessionViewModel
{
	public int SessionId { get; set; }

	public SessionStateEnum State { get; set; } = new("-",-1);

	public SessionTypeEnum? Type { get; set; }

	public CompetitionViewModel? Competition { get; set; }

	public List<IncidentViewModel> Incidents { get; set; } = new();

	public static SessionViewModel? MapEntityToViewModel(Session? session)
	{
		if(session is null)
		{
			return null;
		}

		SessionViewModel sessionViewModel =  new()
		{
			SessionId = session.Id,
			State = session.State,
			Type = session.SessionType
		};

		if(session.Competition is not null)
		{
			sessionViewModel.Competition = new()
			{
				SeasonId = session.Competition.Season!.Id,
				Year = session.Competition.Season!.Year,
				Id = session.Competition.Id,
				Name = session.Competition.Name,
				CircuitId = session.Competition.CircuitId,
				Circuit = new() { Name = session.Competition.Circuit!.Name },
				IsSprint = session.Competition.IsSprint,
				Week = session.Competition.Week,
				CompetitionState = session.Competition.State
			};
		}

		foreach(var incident in session.Incidents)
		{
			sessionViewModel.Incidents.Add(IncidentViewModel.MapEntityToViewModel(incident));
		}

		return sessionViewModel;
	}
}
