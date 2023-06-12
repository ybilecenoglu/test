using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFOrderDal : EFRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public Task<Result<List<Customer>>> GetCustomers(Expression<Func<Customer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
