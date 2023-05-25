using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal CategoryDal;
        
        public CategoryManager(ICategoryDal categoryDal) {
            CategoryDal = categoryDal;
        }
        public async Task<List<CategoryViewModel>> GetCategories(Expression<Func<Category, bool>> filter)
        {
            var categories = filter != null ? await CategoryDal.GetAllAsync(filter) : await CategoryDal.GetAllAsync();
            
            var result = categories.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture

            })
                .OrderBy(x => x.CategoryId)
                .ToList();

            return result;
        }
    }
}
