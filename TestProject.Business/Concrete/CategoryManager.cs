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
        public async Task<Result<List<Category>>> GetCategories(Expression<Func<Category, bool>> filter)
        {
            var categoryResult = filter != null ? await _nhCategoryDal.GetAllAsync(filter) : await _nhCategoryDal.GetAllAsync();
            return categoryResult;
            
        }
        public async Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter)
        {
            var result = await _nhCategoryDal.GetAsync(filter);
            return result;
        }

    }
}
