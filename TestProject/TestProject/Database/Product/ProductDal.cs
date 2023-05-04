using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Database.Product
{
    public class ProductDal : IProductDal
    {
        public void Add(Models.Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                TestProject.Models.Product product = new Models.Product();
                product.ProductName = entity.ProductName;
                product.UnitPrice = entity.UnitPrice;
                product.QuantityPerUnit = entity.QuantityPerUnit;
                product.UnitsInStock = entity.UnitsInStock;

                context.Products.Add(product);
                context.SaveChanges();
            }
        }


        public void Delete(Models.Product product)
        {
            using (NorthwindContext context = new NorthwindContext() )
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public Models.Product Get(Models.Product product)
        {
            throw new NotImplementedException();
        }

        public List<Models.Product> GetAll()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        public List<string> GetCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var categories = new List<string>();
                foreach (var category in context.Categories)
                {
                    categories.Add(category.CategoryName);
                }
                return categories;
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
            throw new NotImplementedException();
        }
    }
}
