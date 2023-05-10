using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Database;
using TestProject.Models;

namespace TestProject.Data
{
    public class CategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(int Id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.FirstOrDefault(x => x.CategoryId == Id);
            }
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
