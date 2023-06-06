using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFProductDal : EFRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        
        public async Task<Result<List<Category>>> GetCategories()
        {
            var result = new Result<List<Category>> { Success = false };
            try
            {
                using (var context = new NorthwindContext())
                {
                    result.Data = await context.Categories.ToListAsync();
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                }
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Message = "Hata oluştu";

                return result;
            }
        }

        public async Task<Result<List<Supplier>>> GetSuppliers()
        {
            var result = new Result<List<Supplier>> { Success = false };
            try
            {
                using (var context = new NorthwindContext())
                {
                    result.Data = await context.Suppliers.ToListAsync();
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                }
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Message = "Hata oluştu";

                return result;
            }
        }
    }
}
