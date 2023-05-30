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

namespace TestProject.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

         public async Task<Result> AddEmployee(Employee employee)
        {
            var result = await _employeeDal.AddAsync(employee);
            return result;
        }

        public async Task<Result> DeleteEmployee(Employee employee)
        {
            var result = await _employeeDal.DeleteAsync(employee);
            return result;
        }

        public async Task<Result<Employee>> GetEmployee(Expression<Func<Employee, bool>> filter)
        {
            var result = await _employeeDal.GetAsync(filter);
            return result;
        }

        public async Task<Result<List<EmployeeViewModel>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            Result<List<EmployeeViewModel>> employees = new Result<List<EmployeeViewModel>>();
            var getEmployeesResult = await _employeeDal.GetAllAsync(filter);
            if (getEmployeesResult.Success == true && getEmployeesResult.Data != null)
            {
                var columns = getEmployeesResult.Data.Select(e => new EmployeeViewModel
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    City = e.City,
                    BirthDate = e.BirthDate,
                    Country = e.Country,
                    Extension = e.Extension,
                    HireDate = e.HireDate,
                    HomePhone = e.HomePhone,
                    Notes = e.Notes,
                    PostalCode = e.PostalCode,
                    Region = e.Region,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy
                })
                    .OrderBy(e => e.EmployeeId)
                    .ToList();

                employees.Success = true;
                employees.Data = columns;
                return employees;
            }
            else
            {
                employees.Success = getEmployeesResult.Success;
                employees.Message = getEmployeesResult.Message;
                return employees;
            }
            
        }

        public async Task<Result> UpdateEmployee(Employee employee)
        {
            var result = await _employeeDal.UpdateAsync(employee);
            return result;
        }
    }
}
