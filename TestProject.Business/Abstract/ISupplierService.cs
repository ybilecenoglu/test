using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetSuppliers(Expression<Func<Supplier,bool>> filter = null);
    }
}
