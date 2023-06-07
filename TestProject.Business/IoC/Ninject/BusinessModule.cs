using Ninject.Modules;
using TestProject.Business.Abstract;
using TestProject.Business.Concrete;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.EF;
using TestProject.DataAccess.Concrete.NHibernate;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.DataAccess.ORM;

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
            Bind<ISupplierService>().To<SupplierManager>().InSingletonScope();
            Bind<IExceptionHandlerService>().To<ExceptionHandlerManager>().InSingletonScope();
            Bind<IConvertImageService>().To<ConvertImageManager>().InSingletonScope();
            Bind<NHibarnateHelper>().To<SqlNhibarnateHelper>().InSingletonScope();

            Bind<ISupplierDal>().To<EFSupplierDal>().InSingletonScope();
            Bind<IProductDal>().To<EFProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();
            Bind<IEmployeeDal>().To<EFEmployeeDal>().InSingletonScope();
            Bind<IOrderDal>().To<EFOrderDal>().InSingletonScope();
        }
    }
}
