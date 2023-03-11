using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;

public class EfRepository<T> : IPenaltyRepository<T> where T : EntityBase, IAggregateRoot
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public EfRepository(RulesPenaltiesF1DbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<T> Add(T entity)
   {
      _dbContext.Add(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
   }

   public async Task Delete(T entity)
   {
      _dbContext.Set<T>().Remove(entity);

      await _dbContext.SaveChangesAsync();
   }

   public async Task<List<T>> GetAllAsync()
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
