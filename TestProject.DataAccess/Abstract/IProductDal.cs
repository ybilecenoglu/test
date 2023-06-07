using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.DataAccess.Concrete;

namespace TestProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<Result<List<Category>>> GetCategories();
        Task<Result<List<Supplier>>> GetSuppliers();

        Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter);
        Task<Result<Supplier>> GetSupplier(Expression<Func<Supplier, bool>> filter);
    }
}
