using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private ISupplierDal SupplierDal;
        public SupplierManager(ISupplierDal supplierDal) { 
            SupplierDal = supplierDal;
        }
        public Task<List<Supplier>> GetSuppliers(Expression<Func<Supplier, bool>> filter)
        {
            return filter != null ? SupplierDal.GetAllAsync(filter) : SupplierDal.GetAllAsync();
        }
    }
}
