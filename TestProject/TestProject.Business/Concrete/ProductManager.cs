using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.EF;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDal ProductDal;

        public ProductManager(IProductDal productDal)
        {
            ProductDal = productDal;
        }

        public void AddProduct(Product product)
        {
            ProductDal.AddAsync(product);
        }

        //Byte tipini image dönüştüren method
        public Image ByteToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public async Task<Product> GetProduct(Expression<Func<Product, bool>> filter)
        {
           var result = await ProductDal.GetAsync(filter);
           return result;
        }

        public async Task<List<ProductViewModel>> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            var products = filter != null ? await ProductDal.GetAllAsync(filter) : await ProductDal.GetAllAsync();
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = products.Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued,
                    CategoryName = context.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName,
                    SupplierName = context.Suppliers.FirstOrDefault(s => s.SupplierId == p.SupplierId).CompanyName

                })
                .OrderBy(x => x.ProductId)
                .ToList();
                return result;
            }
        }

        //Imagelari byte dönüştüren method
        public byte[] ImageToByte(Image image, ImageFormat imageFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var bitMap = new Bitmap(image);
                bitMap.Save(ms, imageFormat);
                //image.Save(ms, format); || Generic GDI+ error when saving an image
                byte[] imageBytes = ms.ToArray();

                return imageBytes;
            }
        }
    }
}
