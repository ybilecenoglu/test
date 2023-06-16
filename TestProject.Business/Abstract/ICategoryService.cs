using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Result<List<Category>>> GetCategories(Expression<Func<Category, bool>> filter = null);
        Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter);
        Task<Result> AddCategory(Category category);
        Task<Result> DeleteCategory(Category category);
        Task<Result> UpdateCategory(Category category);
        
    }
}
