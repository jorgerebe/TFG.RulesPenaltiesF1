using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure;

public class DateTimeService : IDateTimeService
{
	public DateTime Now()
	{
		return DateTime.Now;
	}
}
