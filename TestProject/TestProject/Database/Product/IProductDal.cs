using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Database.Product
{
    interface IProductDal : IRepository<TestProject.Models.Product>
    {
        public List<string> GetCategories();
        public List<Supplier> GetSuppliers();
    }
}
