using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Business;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.DAL.Category
{
    public class CategoryDal : ICategoryDal
    {
        private Utilities utilities = new Utilities();
        public void AddAsync(Models.Category entity)
        {
            utilities.exceptionHandler(async ()=>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    await context.Categories.AddAsync(entity);
                    await context.SaveChangesAsync();
                }
            });
        }

        public async Task<IList<CategoryViewModel>> BindingList(Expression<Func<Models.Category, bool>> filter = null)
        {
            var categories = await GetAllAsync(filter);

            var columns = categories.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture

            })
                .OrderBy(x => x.CategoryId)
                .ToList();


            return columns;
        }
        public void DeleteAsync(Models.Category entity)
        {
            utilities.exceptionHandler(async () =>
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Categories.Remove(entity);
                    await context.SaveChangesAsync();
                }
            });
        }
        public async Task<List<Models.Category>> GetAllAsync(Expression<Func<Models.Category, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? await context.Categories.ToListAsync() : await context.Categories.Where(filter).ToListAsync();
            }
        }
        public async Task<Models.Category> GetAsync(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            }
        }
        public async void UpdateAsync(Models.Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
