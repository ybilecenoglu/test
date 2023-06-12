using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.EF;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        Task<Result<List<Customer>>> GetCustomers(Expression<Func<Customer, bool>> filter = null);
        Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null);
    }
}
