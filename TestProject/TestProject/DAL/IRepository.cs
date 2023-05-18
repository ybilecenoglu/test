using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Database
{
    //Database işlemlerinin gerçeleştiğini generic interface
    interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task<T> GetAsync(int id);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
