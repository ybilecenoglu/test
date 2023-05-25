using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts(Expression<Func<Product, bool>> filter = null);
        Task<Product> GetProduct(Expression<Func<Product, bool>> filter);
        void AddProduct(Product product);
        Image ByteToImage(byte[] bytes);
        byte[] ImageToByte(Image image, ImageFormat imageFormat);
    }
}
