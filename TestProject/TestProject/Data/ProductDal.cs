using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Database
{
    public class ProductDal : IProductDal
    {
        public void Add(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Add(entity);
                context.SaveChanges();
            }
        }


        public void Delete(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Remove(entity);
                context.SaveChanges();
            }
        }

        public Models.Product Get(int Id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == Id);
                return product;
            }
        }

        public List<Models.Product> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        public List<Category> GetCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return context.Categories.ToList();
            }
        }
        public List<Supplier> GetSuppliers()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public void Update(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
