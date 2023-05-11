using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Models;

namespace TestProject.Database
{
    public class ProductDal : IProductDal
    {
        public async void AddAsync(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                await context.Products.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }


        public async void DeleteAsync(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Remove(entity);
                await context.SaveChangesAsync();
            }
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

        public async Task<List<Category>> GetCategoriesAsync(Expression<Func<Models.Category,bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Categories.ToListAsync() : await context.Categories.Where(filter).ToListAsync();
            }
        }
        public async Task<List<Supplier>> GetSuppliersAsync(Expression<Func<Models.Supplier, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Suppliers.ToListAsync() : await context.Suppliers.Where(filter).ToListAsync();
            }
        }

        public async void UpdateAsync(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
