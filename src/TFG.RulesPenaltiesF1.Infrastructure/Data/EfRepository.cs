using System.Threading;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;

public class EfRepository<T> : IRepository<T> where T : EntityBase, IAggregateRoot
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public EfRepository(RulesPenaltiesF1DbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public Task<T> Add(T entity)
   {
      throw new NotImplementedException();
   }

   public Task Delete(T entity)
   {
      throw new NotImplementedException();
   }

   public async Task<List<T>> GetAll()
   {
      return await _dbContext.Set<T>()
         .ToListAsync();
   }

   public async Task<T?> GetByIdAsync<TId>(TId id) where TId: notnull
   {
      return await _dbContext.Set<T>().FindAsync(new object[] { id });
   }

   public Task Update(T entity)
   {
      throw new NotImplementedException();
   }
}
