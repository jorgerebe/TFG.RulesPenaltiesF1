using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces;
public interface IArticleRepository : IRepository<Article>
{
   Task<List<Article>> GetTopLevelArticles();

   Task<Article?> GetArticleById(int id);
}
