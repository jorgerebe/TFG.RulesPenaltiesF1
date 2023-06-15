﻿using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

public class Season : EntityBase, IAggregateRoot
{
	const int MIN_COMPETITORS = 2;
	const int MIN_COMPETITIONS = 2;

	public int Year { get; set; }

	private readonly List<Competitor> _competitors = new();
	public IReadOnlyCollection<Competitor> Competitors => _competitors.AsReadOnly();

	private readonly List<Competition> _competitions = new();
	public IReadOnlyCollection<Competition> Competitions => _competitions.AsReadOnly();

	public int RegulationId { get; set; }
	public Regulation? Regulation { get; set; }

	private Season()
	{

	}

	public Season(int year, List<Competitor> competitors, List<Competition> competitions, Regulation regulation)
	{
		Year = year;
		
		CheckCompetitorsAndCompetitions(competitors, competitions);

		ArgumentNullException.ThrowIfNull(regulation);
		Regulation = regulation;
		RegulationId = Regulation.Id;
	}

	public Season(int year, List<Competitor> competitors, List<Competition> competitions, int regulationId)
	{
		Year = year;

		CheckCompetitorsAndCompetitions(competitors, competitions);
		_competitors = competitors;
		_competitions = competitions;

		RegulationId = regulationId;
	}

	public void CheckCompetitorsAndCompetitions(List<Competitor> competitors, List<Competition> competitions)
	{
		if (competitors is null || competitors.Count < MIN_COMPETITORS)
		{
			throw new ArgumentException($"There must be at least {MIN_COMPETITORS} competitors");
		}

		if (competitions is null || competitions.Count < MIN_COMPETITIONS)
		{
			throw new ArgumentException($"There must be at least {MIN_COMPETITIONS} competitions");
		}
	}
}
