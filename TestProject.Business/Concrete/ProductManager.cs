using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task<Result> AddProduct(Product product)
        {
            var result = await _productDal.AddAsync(product);
            return result;
        }
        public async Task<Result> DeleteProduct(Product product)
        {
            var result = await _productDal.DeleteAsync(product);
            return result;
        }
        public async Task<Result<Product>> GetProduct(Expression<Func<Product, bool>> filter)
        {
            var result = await _productDal.GetAsync(filter);
            return result;

        }
        public async Task<Result<List<ProductViewModel>>> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            Result<List<ProductViewModel>> result = new Result<List<ProductViewModel>> { Success = false};
            
            var productResult = filter != null ? await _productDal.GetAllAsync(filter) : await _productDal.GetAllAsync();
            
            if (productResult.Success)
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                     result.Data = productResult.Data.Select(p => new ProductViewModel
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitsInStock = p.UnitsInStock,
                        UnitsOnOrder = p.UnitsOnOrder,
                        ReorderLevel = p.ReorderLevel,
                        Discontinued = p.Discontinued,
                        CategoryName = context.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName,
                        SupplierName = context.Suppliers.FirstOrDefault(s => s.SupplierId == p.SupplierId).CompanyName

                    })
                    .OrderBy(x => x.ProductId)
                    .ToList();

                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            else { return result; }
                
        }
        public async Task<Result> UpdateProduct(Product product)
        {
            var result = await _productDal.UpdateAsync(product);
            return result;
        }
    }
}
