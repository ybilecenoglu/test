using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.DataAccess.Concrete;

namespace TestProject.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        Task<Result<List<Region>>> GetAllRegion(Expression<Func<Region, bool>> filter = null);
        Task<Result<List<Territory>>> GetAllTerritories(Expression<Func<Territory, bool>> filter = null);
    }
}
