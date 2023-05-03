using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Database
{
    interface IRepository<T>
    {
        List<T> GetAll();
        T Get(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
