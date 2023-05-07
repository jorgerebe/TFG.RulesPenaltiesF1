using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using Autofac.Core;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web
	{
	public static class SeedData
   {
      /*ARTICLES*/
      public static readonly Article article1 = new ("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.\nHowever, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      public static readonly Article subarticle1 = new ("Any Competitor whose driver exceeds the limit during any practice session will be\nfined €100 for each km/h above the limit, up to a maximum of €1000.");
      public static readonly Article subarticle2 = new ("During a sprint session or the race, the stewards may impose any of the penalties\nunder Article 54.3a), 54.3b), 54.3c) or 54.3d) on any driver who exceeds the limit.");

      public static readonly Article article2 = new("Drivers must make every reasonable effort to use the track at all times and may not leave the track without a justifiable reason.");

      /*PENALTIES*/
      public static readonly PenaltyType DQ = new ("Disqualification", "Driver disqualified of the race");
      public static readonly PenaltyType TP = new ("Time Penalty", "Time Penalty");
      public static readonly PenaltyType GP = new ("Drop Grid Positions", "Drop Grid Position");
      public static readonly PenaltyType DT = new ("Drive-Through", "Drive-Through");
      public static readonly PenaltyType StopAndGo = new ("Stop And Go", "Stop And Go");
      public static readonly PenaltyType Reprimand = new ("Reprimand", "Reprimand");
      public static readonly PenaltyType Fine = new ("Fine", "The competitor must pay a fine");

      public static readonly TimePenalty tp_5 = new (TP, 5);
      public static readonly TimePenalty tp_10 = new (TP, 10);
      public static readonly DriveThrough dt = new (DT, 20);
      public static readonly StopAndGo sag = new (StopAndGo, 10, 20);
      public static readonly Reprimand nodrivingReprimand = new (Reprimand, false);
      public static readonly Reprimand drivingReprimand = new (Reprimand, true);
      public static readonly DropGridPositions dropGridPositions3 = new (GP, 3);
      public static readonly DropGridPositions dropGridPositions5 = new (GP, 5);
      public static readonly DropGridPositions dropGridPositions10 = new (GP, 10);
      public static readonly Disqualification dq = new (DQ, false);
      public static readonly Disqualification suspensionNextCompetition = new (DQ, true);
      public static readonly Fine fine = new (Fine);

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
         new(countries[8],"Albert Park Circuit",5.278f,58,1996,80260,"Charles Leclerc", 2022)
      };

      /*Competitors in its method*/

      static List<Competitor> competitors = new();

      /*Competitions*/
      public static List<Competition> competitions = new()
      {
         new(circuits[0], "Bahrain Grand Prix", false, 10),
         new(circuits[1], "Australian Grand Prix", true, 12)
      };

		/*Seasons in its method*/

		/*Drivers in its method*/
		public static List<Driver> drivers = new();


		public static async Task Initialize(IServiceProvider serviceProvider)
      {
         using var dbContext = new RulesPenaltiesF1DbContext(
             serviceProvider.GetRequiredService<DbContextOptions<RulesPenaltiesF1DbContext>>(), null);
         using var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
         // Check if DB has already been seeded before populating

         if (dbContext.Article.Any())
         {
            return;
         }

         await PopulateTestData(dbContext, userManager);
      }
      public static async Task PopulateTestData(RulesPenaltiesF1DbContext dbContext, UserManager<ApplicationUser> userManager)
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
         /*Seasons*/
         PopulateSeasons(dbContext);
			/*Drivers*/
			PopulateDrivers(dbContext);

         // Save again
         dbContext.SaveChanges();
      }

      public static void PopulateArticles(RulesPenaltiesF1DbContext dbContext)
      {
         article1.AddSubArticle(subarticle1);
         article1.AddSubArticle(subarticle2);

         dbContext.Article.Add(article1);
         dbContext.Article.Add(article2);
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

         dbContext.Season.Add(season1);
      }


		public static void PopulateDrivers(RulesPenaltiesF1DbContext dbContext)
		{
			//MCLAREN
			drivers.Add(new Driver("Lando Norris", new DateOnly(1999, 11, 13), competitors[0]));
			drivers.Add(new Driver("Oscar Piastri", new DateOnly(2001, 4, 6), competitors[0]));
			//RED BULL
			drivers.Add(new Driver("Max Verstappen", new DateOnly(1997, 9, 30), competitors[1]));
			drivers.Add(new Driver("Sergio Pérez", new DateOnly(1990, 1, 26), competitors[1]));
			drivers.Add(new Driver("Daniel Ricciardo", new DateOnly(1989, 7, 1), competitors[1]));
			//FERRARI
			drivers.Add(new Driver("Carlos Sainz", new DateOnly(1994, 9, 1), competitors[2]));
			drivers.Add(new Driver("Charles Leclerc", new DateOnly(1997, 10, 16), competitors[2]));
			//MERCEDES
			drivers.Add(new Driver("Lewis Hamilton", new DateOnly(1985, 1, 7), competitors[3]));
			drivers.Add(new Driver("George Russell", new DateOnly(1998, 2, 15), competitors[3]));

			foreach(var driver in drivers)
			{
				dbContext.Driver.Add(driver);
			}
		}
   }
}
