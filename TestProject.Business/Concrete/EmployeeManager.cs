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

        public async Task<Result<List<Region>>> GetAllRegion(Expression<Func<Region, bool>> filter = null)
        {
            var result = await _NHemployeeDal.GetAllRegion(filter);
            return result;
        }

        public async Task<Result<List<Territory>>> GetAllTerritories(Expression<Func<Territory, bool>> filter = null)
        {
            var result = await _NHemployeeDal.GetAllTerritories(filter);
            return result;

        }

        public async Task<Result<Employee>> GetEmployee(Expression<Func<Employee, bool>> filter)
        {
            var result = await _NHemployeeDal.GetAsync(filter);
            return result;
        }

        public async Task<Result<List<EmployeeViewModel>>> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            Result<List<EmployeeViewModel>> employees = new Result<List<EmployeeViewModel>>();
            var getEmployees_Result = await _NHemployeeDal.GetAllAsync(filter);
            if (getEmployees_Result.Success == true && getEmployees_Result.Data != null)
            {
                var columns = getEmployees_Result.Data.Select(e => new EmployeeViewModel
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
                employees.Success = getEmployees_Result.Success;
                employees.Message = getEmployees_Result.Message;
                return employees;
            }
            
        }

        public async Task<Result> UpdateEmployee(Employee employee)
        {
            var result = await _NHemployeeDal.UpdateAsync(employee);
            return result;
        }
    }
}
