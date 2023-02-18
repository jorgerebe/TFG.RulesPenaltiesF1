using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFG.RulesPenaltiesF1.Core;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data;

public class EfRepository<T> : IRepository<T> where T : EntityBase, IAggregateRoot
{
   public void Add(T entity)
   {
      throw new NotImplementedException();
   }

   public void Delete(T entity)
   {
      throw new NotImplementedException();
   }

   public IQueryable<T> GetAll()
   {
      throw new NotImplementedException();
   }

   public T GetById(int id)
   {
      throw new NotImplementedException();
   }

   public void Update(T entity)
   {
      throw new NotImplementedException();
   }
}
