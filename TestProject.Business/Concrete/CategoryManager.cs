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
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal) {
            _categoryDal = categoryDal;
        }
        public async Task<Result> AddCategory(Category category)
        {
            var result = await _categoryDal.AddAsync(category);
            return result;
        }
        public async Task<Result> UpdateCategory(Category category)
        {
            var result = await _categoryDal.UpdateAsync(category);
            return result;

        }
        public async Task<Result> DeleteCategory(Category category)
        {
            var result = await _categoryDal.DeleteAsync(category);
            return result;
        }
        public async Task<Result<List<CategoryViewModel>>> GetCategories(Expression<Func<Category, bool>> filter)
        {
            Result<List<CategoryViewModel>> result = new Result<List<CategoryViewModel>> { Success = false };
            var categoryResult = filter != null ? await _categoryDal.GetAllAsync(filter) : await _categoryDal.GetAllAsync();
            
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
            var result = await _categoryDal.GetAsync(filter);
            return result;
        }

    }
}
