using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Abstract
{
    public interface IEmployeeService
    {
        Task<Result<List<EmployeeViewModel>>> GetEmployees(Expression<Func<Employee, bool>> filter = null);
        Task<Result<Employee>> GetEmployee(Expression<Func<Employee, bool>> filter);
        Task<Result> AddEmployee(Employee employee);
        Task<Result> DeleteEmployee(Employee employee);
        Task<Result> UpdateEmployee(Employee employee);
        Task<Result<List<Region>>> GetAllRegion(Expression<Func<Region, bool>> filter);
        Task<Result<List<Territory>>> GetAllTerritories(Expression<Func<Territory, bool>> filter = null);
    }
}
