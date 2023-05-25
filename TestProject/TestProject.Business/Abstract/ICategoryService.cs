using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories(Expression<Func<Category, bool>> filter = null);
    }
}
