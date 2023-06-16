using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests.Drivers.PageDrivers;
public class ArticlePageDriver
{
	private readonly RulesPenaltiesF1DbContext _dbContext;

	public ArticlePageDriver(RulesPenaltiesF1DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public int getNumberOfArticles()
	{
		return _dbContext.Article.Count();
	}
}
