using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFProductDal : EFRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        
    }
}
