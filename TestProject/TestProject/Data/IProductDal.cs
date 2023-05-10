using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Database
{
    interface IProductDal : IRepository<Models.Product>
    {
        public List<Category> GetCategories();
        public List<Supplier> GetSuppliers();
    }
}
