using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFCategoryDal : EFRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {

    }
}
