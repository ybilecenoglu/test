using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface IOrderService
    {
        Task<Result<List<Order>>> GetAllOrder(Expression<Func<Order, bool>> filter = null);
        Task<Result<Order>> GetOrder(Expression<Func<Order, bool>> filter);
        Task<Result> AddOrder(Order order);
        Task<Result> DeleteOrder(Order order);
        Task<Result> UpdateOrder(Order order);

        Task<Result<List<Customer>>> GetCustomers(Expression<Func<Customer, bool>> filter = null);
        Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null);

    }
}
