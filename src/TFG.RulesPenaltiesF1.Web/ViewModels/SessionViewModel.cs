using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SessionViewModel
{
	public int SessionId { get; set; }

	public SessionStateEnum State { get; set; } = new("-",-1);

	public SessionTypeEnum? Type { get; set; }

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

		foreach(var incident in session.Incidents)
		{
			sessionViewModel.Incidents.Add(IncidentViewModel.MapEntityToViewModel(incident));
		}

		return sessionViewModel;
	}
}
