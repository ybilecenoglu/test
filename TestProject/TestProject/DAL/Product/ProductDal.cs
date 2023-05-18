using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Business;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.DAL.Product
{
    public class ProductDal : IProductDal
    {
        private Utilities utilities = new Utilities();


        public void AddAsync(Models.Product entity)
        {
            //Global hata döndüren fonksiyonumuzun çağırdık
            utilities.returnExc(async () =>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    await context.Products.AddAsync(entity);
                    await context.SaveChangesAsync();
                }
            });
        }
        public void DeleteAsync(Models.Product entity)
        {
            utilities.returnExc(async () =>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Products.Remove(entity);
                    await context.SaveChangesAsync();
                }
            });
        }
        public async Task<Models.Product> GetAsync(int Id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == Id);
                return product;
            }
        }
        public async Task<List<Models.Product>> GetAllAsync(Expression<Func<Models.Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Products.ToListAsync() : await context.Products.Where(filter).ToListAsync();
            }
        }
        public async Task<List<Models.Category>> GetCategoriesAsync(Expression<Func<Models.Category, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Categories.ToListAsync() : await context.Categories.Where(filter).ToListAsync();
            }
        }
        public async Task<List<Supplier>> GetSuppliersAsync(Expression<Func<Supplier, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Suppliers.ToListAsync() : await context.Suppliers.Where(filter).ToListAsync();
            }
        }
        public void UpdateAsync(Models.Product entity)
        {
            utilities.returnExc(async () =>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Update(entity);
                    await context.SaveChangesAsync();
                }
            });
        }
        public async Task<Models.Category> GetCategoryById(int? id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

                return category;
            }
        }

        public async Task<Supplier> GetSupplierById(int? id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
                return supplier;
            }
        }

        public async Task<IList<ProductViewModel>> BindingList(Expression<Func<Models.Product, bool>> filter = null)
        {
            List<Models.Product> products = await GetAllAsync(filter);

            using (var context = new NorthwindContext())
            {
                var columns = products.Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued,
                    CategoryName = context.Categories.FirstOrDefault(x => x.CategoryId == p.CategoryId).CategoryName,
                    SupplierName = context.Suppliers.FirstOrDefault(x => x.SupplierId == p.SupplierId).CompanyName

                })
                .OrderBy(x => x.ProductId)
                .ToList();

                return columns;
            }
        }
    }
}
