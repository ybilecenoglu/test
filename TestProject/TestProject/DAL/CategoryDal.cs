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
        public void AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync(Expression<Func<Models.Category,bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
