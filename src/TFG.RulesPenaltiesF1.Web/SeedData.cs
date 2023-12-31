﻿using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Web;

public static class SeedData
   {
      /*ARTICLES*/
      public static readonly Article article1 = new ("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.However, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      public static readonly Article subarticle1 = new ("Any Competitor whose driver exceeds the limit during any practice session will be fined €100 for each km/h above the limit, up to a maximum of €1000.");

      public static readonly Article article2 = new("Drivers must make every reasonable effort to use the track at all times and may not leave the track without a justifiable reason.");

		public static readonly Article article3 = new("A car will be deemed to have been released either when it has been driven out of its designated garage area (when leaving from the garage) or after it has completely cleared its pit stop position following a pit stop)");
		public static readonly Article subarticle3_1 = new("Cars must not be released from a garage or pit stop position in way that could endanger pit lane personnel or another driver.");
		public static readonly Article subarticle3_2 = new("Competitors must provide a means of clearly establishing, when being viewed from both above and in the front of the car, when a car was released.");

		public static readonly Article article4 = new("Any driver taking part in any free practice session, the qualifying session or the sprint shootout who, in the opinion of the stewards, stops unnecessarily on the circuit or unnecessarily impedes another driver shall be subject to the penalties");

		/*PENALTIES*/
		public static readonly PenaltyType DQ = new ("Disqualification", "Disqualification from the results", true, false);
      public static readonly PenaltyType Suspension = new ("Suspension", "Suspension from the driver’s next Competition", true, false);
      public static readonly PenaltyType TP = new ("Time Penalty", "Applied during the pit stop or after the race", true, false);
      public static readonly PenaltyType GP = new ("Drop Grid Positions", "Drop of grid positions at the driver's next race", true, false);
      public static readonly PenaltyType DT = new ("Drive-Through", "The driver must enter the pit lane and re-join without stopping", true, false);
      public static readonly PenaltyType StopAndGo = new ("Stop And Go", "The driver must enter the pit lane, stop in pit position for the required time and then re-join", true, false);
      public static readonly PenaltyType Reprimand = new ("Reprimand", "", false, false);
      public static readonly PenaltyType Fine = new ("Fine", "The competitor must pay a fine", false, true);

      public static readonly TimePenalty tp_5 = new (TP, 5, true);
      public static readonly TimePenalty tp_10 = new (TP, 10, true);
      public static readonly DriveThrough dt = new (DT, 20, true);
      public static readonly StopAndGo sag = new (StopAndGo, 10, 20, true);
      public static readonly Reprimand nodrivingReprimand = new (Reprimand, false, true);
      public static readonly Reprimand drivingReprimand = new (Reprimand, true, true);
      public static readonly DropGridPositions dropGridPositions3 = new (GP, 3, true);
      public static readonly DropGridPositions dropGridPositions5 = new (GP, 5, true);
      public static readonly DropGridPositions dropGridPositions10 = new (GP, 10, true);
      public static readonly Disqualification dq = new (DQ, DisqualificationTypeEnum.Current, true);
      public static readonly Disqualification suspensionNextCompetition = new (Suspension, DisqualificationTypeEnum.Next, true);
      public static readonly Disqualification disqualificationLimitLicensePoints = new (Suspension, DisqualificationTypeEnum.LicensePointsLimit, false);
      public static readonly Fine fine = new (Fine, true);

      /*REGULATIONS*/

      public static readonly Regulation regulation = new ("testing");

      /*COUNTRIES*/
      public static readonly List<Country> countries = new()
      {
         new ("AFGHANISTAN"),
         new ("ALBANIA"),
         new ("ALGERIA"),
         new ("AMERICAN SAMOA"),
         new ("ANDORRA"),
         new ("ANGOLA"),
         new ("ARGENTINA"),
         new ("ARMENIA"),
         new ("AUSTRALIA"),
         new ("AUSTRIA"),
         new ("AZERBAIJAN"),
         new ("BAHAMAS"),
         new ("BAHRAIN"),
         new ("BANGLADESH"),
         new ("BARBADOS"),
         new ("BELARUS"),
         new ("BELGIUM"),
         new ("BELIZE"),
         new ("BENIN"),
         new ("BERMUDA"),
         new ("BHUTAN"),
         new ("BOLIVIA"),
         new ("BOSNIA AND HERZEGOVINA"),
         new ("BOTSWANA"),
         new ("BRAZIL"),
         new ("BULGARIA"),
         new ("BURKINA FASO"),
         new ("BURUNDI"),
         new ("CAMBODIA"),
         new ("CAMEROON"),
         new ("CANADA"),
         new ("CAPE VERDE ISLANDS"),
         new ("CHAD"),
         new ("CHILE"),
         new ("CHINA"),
         new ("COLOMBIA"),
         new ("CONGO"),
         new ("COSTA RICA"),
         new ("CROATIA"),
         new ("CUBA"),
         new ("CYPRUS"),
         new ("CZECH REPUBLIC"),
         new ("DENMARK"),
         new ("DJIBOUTI"),
         new ("DOMINICA"),
         new ("DOMINICAN REPUBLIC"),
         new ("ECUADOR"),
         new ("EGYPT"),
         new ("EL SALVADOR"),
         new ("ERITREA"),
         new ("ESTONIA"),
         new ("ETHIOPIA"),
         new ("FIJI"),
         new ("FINLAND"),
         new ("FRANCE"),
         new ("FRENCH POLYNESIA"),
         new ("GABON"),
         new ("GAMBIA"),
         new ("GEORGIA"),
         new ("GERMANY"),
         new ("GHANA"),
         new ("GREECE"),
         new ("GRENADA"),
         new ("GUATEMALA"),
         new ("GUINEA"),
         new ("GUYANA"),
         new ("HAITI"),
         new ("HONDURAS"),
         new ("HUNGARY"),
         new ("ICELAND"),
         new ("INDIA"),
         new ("INDONESIA"),
         new ("IRAN"),
         new ("IRAQ"),
         new ("IRELAND"),
         new ("ISRAEL"),
         new ("ITALY"),
         new ("JAMAICA"),
         new ("JAPAN"),
         new ("JORDAN"),
         new ("KAZAKHSTAN"),
         new ("KENYA"),
         new ("NORTHERN IRELAND"),
         new ("NORTH KOREA"),
         new ("SOUTH KOREA"),
         new ("KUWAIT"),
         new ("LATVIA"),
         new ("LEBANON"),
         new ("LIBERIA"),
         new ("LIBYA"),
         new ("LITHUANIA"),
         new ("LUXEMBOURG"),
         new ("MADAGASCAR"),
         new ("MALAWI"),
         new ("MALAYSIA"),
         new ("MALDIVES"),
         new ("MALI"),
         new ("MALTA"),
         new ("MAURITANIA"),
         new ("MAURITIUS"),
         new ("MEXICO"),
         new ("MONACO"),
         new ("MONGOLIA"),
         new ("MONTENEGRO"),
         new ("MOROCCO"),
         new ("MOZAMBIQUE"),
         new ("NAMIBIA"),
         new ("NEPAL"),
         new ("NETHERLANDS"),
         new ("NEW ZEALAND"),
         new ("NICARAGUA"),
         new ("NIGER"),
         new ("NIGERIA"),
         new ("NORWAY"),
         new ("OMAN"),
         new ("PAKISTAN"),
         new ("PANAMA"),
         new ("PAPUA NEW GUINEA"),
         new ("PARAGUAY"),
         new ("PERU"),
         new ("PHILIPPINES"),
         new ("POLAND"),
         new ("PORTUGAL"),
         new ("QATAR"),
         new ("ROMANIA"),
         new ("RWANDA"),
         new ("SAUDI ARABIA"),
         new ("SENEGAL"),
         new ("SERBIA"),
         new ("SIERRA LEONE"),
         new ("SINGAPORE"),
         new ("SLOVAKIA"),
         new ("SLOVENIA"),
         new ("SOLOMON ISLANDS"),
         new ("SOMALIA"),
         new ("SOUTH AFRICA"),
         new ("SPAIN"),
         new ("SRI LANKA"),
         new ("SUDAN"),
         new ("SURINAME"),
         new ("SWAZILAND"),
         new ("SWEDEN"),
         new ("SWITZERLAND"),
         new ("TAIWAN"),
         new ("TAJIKISTAN"),
         new ("THAILAND"),
         new ("TOGO"),
         new ("TRINIDAD AND TOBAGO"),
         new ("TUNISIA"),
         new ("TURKEY"),
         new ("TURKMENISTAN"),
         new ("TUVALU"),
         new ("UGANDA"),
         new ("UKRAINE"),
         new ("UNITED ARAB EMIRATES"),
         new ("UNITED KINGDOM"),
         new ("UNITED STATES"),
         new ("URUGUAY"),
         new ("UZBEKISTAN"),
         new ("VANUATU"),
         new ("VENEZUELA"),
         new ("VIET NAM"),
         new ("YEMEN"),
         new ("ZAMBIA"),
      };

      /*Circuits*/
      public static readonly List<Circuit> circuits = new()
      {
         new(countries[12],"Bahrain International Circuit",5.412f,57,2004,91447,"Pedro de la Rosa", 2005),
         new(countries[8],"Albert Park Circuit",5.278f,58,1996,80260,"Charles Leclerc", 2022),
         new(countries[155],"Silverstone Circuit",5.891f,52,1950,87097,"Max Verstappen Leclerc", 2020)
      };

      /*Competitors in its method*/

      static List<Competitor> competitors = new();

      /*Competitions*/
      public static List<Competition> competitions = new()
      {
         new(circuits[0], "Bahrain Grand Prix", false, 1),
         new(circuits[1], "Australian Grand Prix", true, 6)
      };

	/*Seasons in its method*/

	/*Drivers in its method*/
	public static List<Driver> drivers = new();


	public static async Task Initialize(IServiceProvider serviceProvider)
      {
         using var dbContext = new RulesPenaltiesF1DbContext(
             serviceProvider.GetRequiredService<DbContextOptions<RulesPenaltiesF1DbContext>>(), null);
         using var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var dateTimeService = serviceProvider.GetRequiredService<IDateTimeService>();

			// Check if DB has already been seeded before populating

         if (dbContext.Article.Any())
         {
            return;
         }

         await PopulateTestData(dbContext, userManager, dateTimeService);
      }
      public static async Task PopulateTestData(RulesPenaltiesF1DbContext dbContext, UserManager<ApplicationUser> userManager, IDateTimeService dateTimeService)
      {

         /*Remove every item from then DB*/

         foreach (var item in dbContext.Article)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.Penalty)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.PenaltyType)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.RegulationArticle)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.RegulationPenalty)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.Regulation)
         {
            dbContext.Remove(item);
         }

         foreach (var item in dbContext.Country)
         {
            dbContext.Remove(item);
         }

         foreach (var item in dbContext.Circuit)
         {
            dbContext.Remove(item);
         }

         foreach (var item in dbContext.Competitor)
         {
            dbContext.Remove(item);
         }

         foreach (var item in dbContext.Season)
         {
            dbContext.Remove(item);
         }

         // Save changes

         dbContext.SaveChanges();

         // Populate

         /*Articles*/
         PopulateArticles(dbContext);
         /*Penalties*/
         PopulatePenalties(dbContext);
         /*Regulations*/
         PopulateRegulations(dbContext);

         dbContext.SaveChanges();

         /*Countries*/
         PopulateCountries(dbContext);
         /*Circuits*/
         PopulateCircuits(dbContext);
         /*Competitors*/
         await PopulateCompetitors(dbContext, userManager);
			/*Drivers*/
			await PopulateDrivers(dbContext, dateTimeService);
			/*Seasons*/
			PopulateSeasons(dbContext);

         // Save again
         dbContext.SaveChanges();
      }

      public static void PopulateArticles(RulesPenaltiesF1DbContext dbContext)
      {
         article1.AddSubArticle(subarticle1);

         article3.AddSubArticle(subarticle3_1);
         article3.AddSubArticle(subarticle3_2);

         dbContext.Article.Add(article1);
         dbContext.Article.Add(article2);
         dbContext.Article.Add(article3);
         dbContext.Article.Add(article4);
      }

      public static void PopulatePenalties(RulesPenaltiesF1DbContext dbContext)
      {
         /*Penalty Types*/
         dbContext.PenaltyType.Add(DQ);
         dbContext.PenaltyType.Add(TP);
         dbContext.PenaltyType.Add(GP);
         dbContext.PenaltyType.Add(DT);
         dbContext.PenaltyType.Add(StopAndGo);
         dbContext.PenaltyType.Add(Reprimand);
         dbContext.PenaltyType.Add(Fine);

         /*Penalties*/

         dbContext.Penalty.Add(tp_5);
         dbContext.Penalty.Add(tp_10);
         dbContext.Penalty.Add(dt);
         dbContext.Penalty.Add(sag);
         dbContext.Penalty.Add(nodrivingReprimand);
         dbContext.Penalty.Add(drivingReprimand);
         dbContext.Penalty.Add(dropGridPositions3);
         dbContext.Penalty.Add(dropGridPositions5);
         dbContext.Penalty.Add(dropGridPositions10);
         dbContext.Penalty.Add(dq);
         dbContext.Penalty.Add(suspensionNextCompetition);
         dbContext.Penalty.Add(tp_10);
         dbContext.Penalty.Add(fine);
      }

      public static void PopulateRegulations(RulesPenaltiesF1DbContext dbContext)
      {
         regulation.AddArticle(article1);
         regulation.AddArticle(article2);
         regulation.AddPenalty(tp_5);
         regulation.AddPenalty(tp_10);
         regulation.AddPenalty(nodrivingReprimand);
         regulation.AddPenalty(fine);
         dbContext.Regulation.Add(regulation);
      }

      public static void PopulateCountries(RulesPenaltiesF1DbContext dbContext)
      {
         foreach(var country in countries)
         {
            dbContext.Country.Add(country);
         }
      }

      public static void PopulateCircuits(RulesPenaltiesF1DbContext dbContext)
      {
         foreach(var circuit in circuits)
         {
            Console.WriteLine(circuit.Id + " - " + circuit.Name);
            dbContext.Circuit.Add(circuit);
         }
      }

      public static async Task PopulateCompetitors(RulesPenaltiesF1DbContext dbContext, UserManager<ApplicationUser> userManager)
      {
         competitors.Add(new Competitor("McLaren", "Woking, United Kingdom", (await userManager.FindByEmailAsync("stella@teamprincipal.com"))!.Id, "Mercedes"));
         competitors.Add(new Competitor("Red Bull Racing", "Milton Keynes, United Kingdom", (await userManager.FindByEmailAsync("horner@teamprincipal.com"))!.Id, "Honda RBPT"));
         competitors.Add(new Competitor("Scuderia Ferrari", "Maranello, Italy", (await userManager.FindByEmailAsync("vasseur@teamprincipal.com"))!.Id, "Ferrari"));
         competitors.Add(new Competitor("Mercedes-AMG Formula One Team", "Brackley, United Kingdom", (await userManager.FindByEmailAsync("wolff@teamprincipal.com"))!.Id, "Mercedes"));

         foreach(var competitor in competitors)
         {
            dbContext.Competitor.Add(competitor);
         }
      }

   public static void PopulateSeasons(RulesPenaltiesF1DbContext dbContext)
   {
		List<Competitor> seasonCompetitors = new()
		{
			competitors[1],
			competitors[3]
		};

      Season season1 = new Season(2023, seasonCompetitors, competitions, regulation);

		competitions[0].StartCompetition();

		List<Participation> participations_2 = new();
		Participation participation_3 = new(competitions[0], competitors[3], drivers[7]);
		Participation participation_4 = new(competitions[0], competitors[3], drivers[8]);
		participations_2.Add(participation_3);
		participations_2.Add(participation_4);

		competitions[0].AddParticipations(participations_2);


		dbContext.Season.Add(season1);
	}


	public async static Task PopulateDrivers(RulesPenaltiesF1DbContext dbContext, IDateTimeService dateTimeService)
	{
		//MCLAREN
		drivers.Add(new Driver("Lando Norris", new DateOnly(1999, 11, 13), competitors[0], dateTimeService));
		drivers.Add(new Driver("Oscar Piastri", new DateOnly(2001, 4, 6), competitors[0], dateTimeService));
		//RED BULL
		drivers.Add(new Driver("Max Verstappen", new DateOnly(1997, 9, 30), competitors[1], dateTimeService));
		drivers.Add(new Driver("Sergio Pérez", new DateOnly(1990, 1, 26), competitors[1], dateTimeService));
		drivers.Add(new Driver("Daniel Ricciardo", new DateOnly(1989, 7, 1), null, dateTimeService));
		//FERRARI
		drivers.Add(new Driver("Carlos Sainz", new DateOnly(1994, 9, 1), competitors[2], dateTimeService));
		drivers.Add(new Driver("Charles Leclerc", new DateOnly(1997, 10, 16), competitors[2], dateTimeService));
		//MERCEDES
		drivers.Add(new Driver("Lewis Hamilton", new DateOnly(1985, 1, 7), competitors[3], dateTimeService));
		drivers.Add(new Driver("George Russell", new DateOnly(1998, 2, 15), competitors[3], dateTimeService));

		foreach(var driver in drivers)
		{
			dbContext.Driver.Add(driver);
		}
		await dbContext.SaveChangesAsync();
	}
   }
