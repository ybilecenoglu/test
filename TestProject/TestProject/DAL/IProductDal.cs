using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Database
{
    interface IProductDal : IRepository<Models.Product>
    {
        Task<List<Category>> GetCategoriesAsync(Expression<Func<Models.Category,bool>> filter=null);
        Task<List<Supplier>> GetSuppliersAsync(Expression<Func<Models.Supplier, bool>> filter = null);
    }
}
