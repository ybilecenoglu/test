using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Database;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.DAL.Category
{
    internal interface ICategoryDal : IRepository<Models.Category>
    {
        Task<IList<CategoryViewModel>> BindingList(Expression<Func<Models.Category, bool>> filter = null);
    }
}
