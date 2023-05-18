using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Database;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.DAL.Product
{
    interface IProductDal : IRepository<Models.Product>
    {
        Task<List<Models.Category>> GetCategoriesAsync(Expression<Func<Models.Category, bool>> filter = null);
        Task<IList<ProductViewModel>> BindingList(Expression<Func<Models.Product, bool>> filter = null);
        Task<List<Supplier>> GetSuppliersAsync(Expression<Func<Supplier, bool>> filter = null);
        Task<Models.Category> GetCategoryById(int? id);
        Task<Supplier> GetSupplierById(int? id);
    }
}
