using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface IProductService
    {
        Task<Result<List<ProductViewModel>>> GetProducts(Expression<Func<Product, bool>> filter = null);
        Task<Result<List<Category>>> GetCategories(Expression<Func<Category, bool>> filter = null);
        Task<Result<List<Supplier>>> GetSuppliers(Expression<Func<Supplier, bool>> filter = null);
        Task<Result<Product>> GetProduct(Expression<Func<Product, bool>> filter);
        Task<Result> DeleteProduct(Product product);
        Task<Result> AddProduct(Product product);
        Task<Result> UpdateProduct(Product product);
        
    }
}
