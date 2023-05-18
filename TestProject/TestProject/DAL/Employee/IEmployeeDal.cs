using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Database;
using TestProject.ViewModels;

namespace TestProject.DAL.Employee
{
    internal interface IEmployeeDal : IRepository<Models.Employee>
    {
        Task<IList<EmployeeViewModel>> BindingList(Expression<Func<Models.Employee, bool>> filter);
        Task<List<Models.Region>> GetRegions(Expression<Func<Models.Region, bool>> filter);
        Task<List<Models.Territory>> GetTerritories(Expression<Func<Models.Territory, bool>> filter);

    }
}
