using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SessionViewModel
{
	public int SessionId { get; set; }

	public SessionStateEnum State { get; set; } = new("-",-1);

	public SessionTypeEnum? Type { get; set; }
}
