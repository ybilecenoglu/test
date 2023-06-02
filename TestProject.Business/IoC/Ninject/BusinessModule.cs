using Ninject.Modules;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.EF;

namespace TestProject.Business.IoC.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IUtilitiesServices>().To<UtilitiesManager>().InSingletonScope();

            Bind<IProductDal>().To<EFProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();
            Bind<IEmployeeDal>().To<EFEmployeeDal>().InSingletonScope();
            Bind<IOrderDal>().To<EFOrderDal>().InSingletonScope();
        }
    }
}
