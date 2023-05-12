using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Database;
using TestProject.Models;

namespace TestProject.Data
{
    public class CategoryDal : ICategoryDal
    {
        public async void AddAsync(Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                await context.Categories.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public void DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Models.Category,bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Categories.ToListAsync() : await context.Categories.Where(filter).ToListAsync();
            }
        }

        public async Task<Category> GetAsync(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            }
        }

        public void UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
