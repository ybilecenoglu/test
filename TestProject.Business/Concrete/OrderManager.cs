using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public async Task<Result> AddOrder(Order order)
        {
            var result = await _orderDal.AddAsync(order);
            return result;
        }

        public async Task<Result> DeleteOrder(Order order)
        {
            var result = await _orderDal.DeleteAsync(order);
            return result;
        }

        public async Task<Result<List<Order>>> GetAllOrder(Expression<Func<Order, bool>> filter = null)
        {
            var result = await _orderDal.GetAllAsync(filter);
            return result;
        }

        public async Task<Result<Order>> GetOrder(Expression<Func<Order, bool>> filter)
        {
            var result = await _orderDal.GetAsync(filter);
            return result;
        }

        public async Task<Result> UpdateOrder(Order order)
        {
            var result = await _orderDal.UpdateAsync(order);
            return result;
        }
    }
}
