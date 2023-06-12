using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.Concrete.NHibernate;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private NHOrderDal NHOrderDal;
        public OrderManager(NHOrderDal orderDal)
        {
            NHOrderDal = orderDal;
        }
        public async Task<Result> AddOrder(Order order)
        {
            var result = await NHOrderDal.AddAsync(order);
            return result;
        }

        public async Task<Result> DeleteOrder(Order order)
        {
            var result = await NHOrderDal.DeleteAsync(order);
            return result;
        }

        public async Task<Result<List<Order>>> GetAllOrder(Expression<Func<Order, bool>> filter = null)
        {
            var order_result = await NHOrderDal.GetAllAsync(filter);
            return order_result;
        }

        public async Task<Result<List<Customer>>> GetCustomers(Expression<Func<Customer, bool>> filter = null)
        {
            var result = await NHOrderDal.GetCustomers(filter);
            return result;
        }

        public async Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            var result = await NHOrderDal.GetEmployees(filter);
            return result;
        }

        public async Task<Result<Order>> GetOrder(Expression<Func<Order, bool>> filter)
        {
            var result = await NHOrderDal.GetAsync(filter);
            return result;
        }

        public async Task<Result> UpdateOrder(Order order)
        {
            var result = await NHOrderDal.UpdateAsync(order);
            return result;
        }
    }
}
