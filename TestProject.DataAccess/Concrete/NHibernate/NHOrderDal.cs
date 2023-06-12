using Microsoft.EntityFrameworkCore;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.IoC.Ninject;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.DataAccess.ORM;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHOrderDal : NHibarnateRepository<Order>, IOrderDal
    {
        private SqlNhibarnateHelper SqlNhibarnateHelper;
        private IExceptionHandlerService ExceptionHandlerService;
        public NHOrderDal(SqlNhibarnateHelper sqlNhibarnateHelper) : base(sqlNhibarnateHelper)
        {
            SqlNhibarnateHelper = sqlNhibarnateHelper;
            ExceptionHandlerService = InstanceFactory.GetInstance<ExceptionHandlerManager>();
        }

        public async Task<Result<List<Customer>>> GetCustomers(Expression<Func<Customer, bool>> filter = null)
        {
            var customer_result = new Result<List<Customer>> { Success = false };
            var exception_result = await ExceptionHandlerService.ReturnException(async () =>
            {
                using (var session = SqlNhibarnateHelper.OpenSession())
                {
                    customer_result.Data = filter != null ? await Task.FromResult(session.Query<Customer>().Where(filter).ToList()) : await Task.FromResult(session.Query<Customer>().ToList());
                    customer_result.Success = true;
                    customer_result.Message = "Success";
                }
            });
            if (exception_result.Success == false)
            {
                customer_result.Message = $"{exception_result.Message}";
                return customer_result;
            }
            else
                return customer_result;
        }

        public async Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            var employee_result = new Result<List<Employee>> { Success = false };
            var exception_result = await ExceptionHandlerService.ReturnException(async () =>
            {
                using (var session = SqlNhibarnateHelper.OpenSession())
                {
                    employee_result.Data = filter != null ? await Task.FromResult(session.Query<Employee>().Where(filter).ToList()) : await Task.FromResult(session.Query<Employee>().ToList());
                    employee_result.Success = true;
                    employee_result.Message = "Success";
                }
            });
            if (exception_result.Success == true)
                return employee_result;
            else
                employee_result.Message = exception_result.Message; return employee_result;
        }
    }
}
