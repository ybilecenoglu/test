using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.NHibernate;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private NHCategoryDal _nhCategoryDal;
        public CategoryManager(NHCategoryDal nHCategoryDal) {
            _nhCategoryDal = nHCategoryDal;
        }
        public async Task<Result> AddCategory(Category category)
        {
            var result = await _nhCategoryDal.AddAsync(category);
            return result;
        }
        public async Task<Result> UpdateCategory(Category category)
        {
            var result = await _nhCategoryDal.UpdateAsync(category);
            return result;

        }
        public async Task<Result> DeleteCategory(Category category)
        {
            var result = await _nhCategoryDal.DeleteAsync(category);
            return result;
        }
        public async Task<Result<List<CategoryViewModel>>> GetCategories(Expression<Func<Category, bool>> filter)
        {
            Result<List<CategoryViewModel>> result = new Result<List<CategoryViewModel>> { Success = false };
            var categoryResult = filter != null ? await _nhCategoryDal.GetAllAsync(filter) : await _nhCategoryDal.GetAllAsync();
            
            if (categoryResult.Success == true)
            {
                result.Data = categoryResult.Data.Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    Picture = x.Picture

                })
                .OrderBy(x => x.CategoryId)
                .ToList();
                result.Success = true;
                result.Message = "Success";
                return result;
            }
            else
                return result;
        }
        public async Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter)
        {
            var result = await _nhCategoryDal.GetAsync(filter);
            return result;
        }

    }
}
