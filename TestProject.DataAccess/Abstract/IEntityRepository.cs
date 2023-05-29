using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Abstract
{
    //Database işlemlerinin gerçeleştiğini generic interface
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        Task<Result<List<T>>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<Result<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<Result> AddAsync(T entity);
        Task<Result> UpdateAsync(T entity);
        Task<Result> DeleteAsync(T entity);
    }
}
