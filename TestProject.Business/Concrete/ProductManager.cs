using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.Business.Validation.Fluent;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.DataAccess.Concrete.NHibernate;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class ProductManager : IProductService
    {

        //private IProductDal _productDal;
        private NHProductDal _nhProductDal;
        private ProductValidator _productValidator;
        public ProductManager(NHProductDal NHProductDal)
        {
            _nhProductDal = NHProductDal;
            _productValidator = new ProductValidator();
        }
        public async Task<Result> AddProduct(Product product)
        {
            var add_result = new Result { Success = false };
            var validate_result = await _productValidator.ValidateAsync(product);

            if (validate_result.Errors.Count > 0)
            {
                foreach (var error in validate_result.Errors)
                {
                    add_result.Success = false;
                    add_result.Message += error.ErrorMessage + Environment.NewLine;
                }

                return add_result;
            }
            else
                add_result = await _nhProductDal.AddAsync(product);
            return add_result;
        }
        public async Task<Result> DeleteProduct(Product product)
        {
            var result = await _nhProductDal.DeleteAsync(product);
            return result;
        }
        public async Task<Result<List<Category>>> GetCategories(Expression<Func<Category, bool>> filter = null)
        {
            var result = await _nhProductDal.GetCategories();
            return result;
        }
        public async Task<Result<List<Supplier>>> GetSuppliers(Expression<Func<Supplier, bool>> filter = null)
        {
            var result = await _nhProductDal.GetSuppliers();
            return result;
        }
        public async Task<Result<Product>> GetProduct(Expression<Func<Product, bool>> filter)
        {
            var result = await _nhProductDal.GetAsync(filter);
            return result;

        }
        public async Task<Result<List<ProductViewModel>>> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            Result<List<ProductViewModel>> result = new Result<List<ProductViewModel>> { Success = false };

            var productResult = filter != null ? await _nhProductDal.GetAllAsync(filter) : await _nhProductDal.GetAllAsync();

            if (productResult.Success)
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
                    CategoryName = GetCategoryName(p.CategoryId).Result,
                    CompanyName = GetCompanyName(p.SupplierId).Result
                })
               .OrderBy(x => x.ProductId)
               .ToList();

                result.Success = true;
                result.Message = "Success";

                return result;

            }
            else { return result; }

        }
        public async Task<Result> UpdateProduct(Product product)
        {
            var result = await _nhProductDal.UpdateAsync(product);
            return result;
        }

        public async Task<string> GetCategoryName(int? categoryId)
        {
            var category_result = await _nhProductDal.GetCategory(x => x.CategoryId == categoryId);
            if (category_result.Success == true && category_result.Data != null)
            {
                return category_result.Data.CategoryName;
            }
            else
                return null;
        }

        public async Task<string> GetCompanyName(int? supplierId)
        {
            var supplier_result = await _nhProductDal.GetSupplier(x => x.SupplierId == supplierId);
            if (supplier_result.Success == true && supplier_result.Data != null)
            {
                return supplier_result.Data.CompanyName;
            }
            else
                return null;
        }
    }
}
