namespace TFG.RulesPenaltiesF1.Core.Interfaces
{
   public interface IRepository<T> where T : EntityBase, IAggregateRoot
   {
      T GetById(int id);
      IQueryable<T> GetAll();
      void Add(T entity);
      void Update(T entity);
      void Delete(T entity);
   }
}
