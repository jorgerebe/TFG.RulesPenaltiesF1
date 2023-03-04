using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;
public class ArticleRepository : EfRepository<Article>, IArticleRepository
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public ArticleRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<List<Article>> GetTopLevelArticles()
   {
      return await _dbContext.Set<Article>()
        .Where(a => !_dbContext.Set<Article>().Any(sub => sub.SubArticles.Contains(a)))
        .Include(a => a.SubArticles)
        .ToListAsync();
   }

   public async Task<Article?> GetArticleById(int id)
   {
      return await _dbContext.Article
                    .Where(b => b.Id == id)
                    .Include(b => b.SubArticles)
                    .FirstOrDefaultAsync();
   }

}
