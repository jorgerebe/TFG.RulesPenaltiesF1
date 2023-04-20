using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class DriverViewModel
{
	public int Id { get; set; }

	[Required]
	[MinLength(5)]
	public string Name { get; set; } = string.Empty;

	[Required]
	[DisplayName("Date birth")]
	public DateOnly DateBirth { get; set; }

	[DisplayName("License Points")]
	public int LicensePoints { get; set; }

	[Required]
	[DisplayName("Competitor")]
	public int CompetitorId { get; set; }

	public CompetitorViewModel? Competitor { get; set; }
}
