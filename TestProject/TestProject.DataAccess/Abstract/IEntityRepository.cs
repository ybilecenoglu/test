using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Abstract
{
    //Database işlemlerinin gerçeleştiğini generic interface
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
