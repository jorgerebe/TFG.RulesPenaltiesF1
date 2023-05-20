using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CompetitionViewModel
{
   public int Id { get; set; }

	public int Year { get; set; }

	public int SeasonId { get; set; }

	[Required]
   public string Name { get; set; } = string.Empty;

   [Required]
   [DisplayName("Circuit")]
   public int CircuitId { get; set; }

   public CircuitViewModel? Circuit { get; set; }

   [Required]
   [DisplayName("Sprint Race")]
   public bool IsSprint { get; set; }

   [Required]
	[Range(1, 53, ErrorMessage ="A year can't have less than 1 week or more than 53")]
   public int Week { get; set; }

	[DisplayName("State")]
	public CompetitionStateEnum CompetitionState { get; set; } = CompetitionStateEnum.NotStarted;

	public List<SessionViewModel> Sessions { get; set; } = new();
	public List<ParticipationViewModel> Participations { get; set; } = new();


	public static CompetitionViewModel MapEntityToViewModel(Competition competition)
	{
		ArgumentNullException.ThrowIfNull(competition);

		CompetitionViewModel competitionViewModel = new()
		{
			SeasonId = competition.Season!.Id,
			Year = competition.Season!.Year,
			Id = competition.Id,
			Name = competition.Name,
			CircuitId = competition.CircuitId,
			Circuit = new() { Name = competition.Circuit!.Name },
			IsSprint = competition.IsSprint,
			Week = competition.Week,
			CompetitionState = competition.State
		};

		foreach (var session in competition.Sessions)
		{
			competitionViewModel.Sessions.Add(
				new SessionViewModel()
				{
					SessionId = session.Id,
					State = session.State,
					Type = session.SessionType
				}
			);
		}

		foreach (var participation in competition.Participations)
		{
			competitionViewModel.Participations.Add(
				new ParticipationViewModel()
				{
					CompetitionId = competition.Id,
					DriverId = participation.DriverId,
					Driver = DriverViewModel.MapEntityToViewModel(participation.Driver!),
					CompetitorId = participation.CompetitorId,
					Competitor = CompetitorViewModel.MapEntityToViewModel(participation.Competitor!)
				}
			);
		}

		return competitionViewModel;
	}
}
