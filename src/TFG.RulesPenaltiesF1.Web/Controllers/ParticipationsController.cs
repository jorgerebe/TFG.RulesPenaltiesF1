using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class ParticipationsController : Controller
{
	public ParticipationsController()
	{
			
	}

	[HttpGet]
	[Authorize(Roles = "TeamPrincipal")]
	public IActionResult Create(int? competitionId)
	{
		if(competitionId is null)
		{
			return NotFound();
		}

		return NotFound();
	}
}
