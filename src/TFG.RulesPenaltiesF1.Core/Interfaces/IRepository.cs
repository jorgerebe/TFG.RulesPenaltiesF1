namespace TFG.RulesPenaltiesF1.Core.Interfaces
{
   public interface IRepository<T> where T : EntityBase, IAggregateRoot
   {
      Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;
      Task<List<T>> GetAllAsync();
      Task<T> Add(T entity);
      Task Update(T entity);
      Task Delete(T entity);
   }
}
