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
        public async Task<List<Supplier>> GetSuppliers(Expression<Func<Supplier, bool>> filter)
        {
            var result = filter != null ? await SupplierDal.GetAllAsync(filter) : await  SupplierDal.GetAllAsync();
            if (result.Success == true)
            {
                return result.Data;
            }
            else
                return null;
        }
    }
}
