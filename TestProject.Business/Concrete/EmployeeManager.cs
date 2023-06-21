using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;
using System.Linq.Expressions;
using TestProject.DataAccess.Concrete.NHibernate;

namespace TestProject.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private NHEmployeeDal _NHemployeeDal;

        public EmployeeManager(NHEmployeeDal nhEmployeeDal)
        {
            _NHemployeeDal = nhEmployeeDal;
        }

         public async Task<Result> AddEmployee(Employee employee)
        {
            var result = await _NHemployeeDal.AddAsync(employee);
            return result;
        }

        public async Task<Result> DeleteEmployee(Employee employee)
        {
            var result = await _NHemployeeDal.DeleteAsync(employee);
            return result;
        }

        public async Task<Result<Employee>> GetEmployee(Expression<Func<Employee, bool>> filter)
        {
            var result = await _NHemployeeDal.GetAsync(filter);
            return result;
        }

        public async Task<Result<List<Employee>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
           
            var employees_result = await _NHemployeeDal.GetAllAsync(filter);
            return employees_result;
            
        }

        public async Task<Result> UpdateEmployee(Employee employee)
        {
            var result = await _NHemployeeDal.UpdateAsync(employee);
            return result;
        }
    }
}
